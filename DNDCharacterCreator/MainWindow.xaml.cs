using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DocumentFormat.OpenXml.Packaging;
using Microsoft.Office.Interop;
namespace DNDCharacterCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();

            Main.Content = new CharacterNamePage();
        }
        //This method is the main function to find and replace keywords within 
        //the template word doc while creating and displaying a new document
        public void FindReplace(string findText, string replaceText)
        {
            //Setting the location of the template, that lies within the resources
            //folder of the project, for later use.
            string executableLocation = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string fileLocation = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Resources/CharacterSheetTestWord.docx");
            
            //Initializing a word aplication object
            var app = new Microsoft.Office.Interop.Word.Application();
            
            //Initializing a word document object as the template word document
            var doc = app.Documents.Open(fileLocation);

            //setting an object for the shapes within the word document
            var shapes = doc.Shapes;

            var replacements = new Dictionary<string, string>();
            replacements.Add("<Name>", "Test");
            replacements.Add("<Class>", "Test2");

            //Looping through shapes within the word document finding and replacing
            //key word with user entered words
            foreach (var replacement in replacements)
            {
                foreach (Microsoft.Office.Interop.Word.Shape shape in shapes)
                {
                    string initialText = shape.TextFrame.TextRange.Text;
                    string resultingText = initialText.Replace(replacement.Key, replacement.Value);
                    shape.TextFrame.TextRange.Text = resultingText;
                }
            }
            //initializing a string with the file path for the new finished word doc to be save to
            string saveLoc = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tester.docx");
            doc.SaveAs2(saveLoc);

            //reinitializing the word application to null so to stop word applications
            //stacking within the background of the computer and comsuming more memory
            app = null;

            //close the word doc to also help stop stacking of word instances within
            //the background as well
            doc.Close();

            //Opening the new finished word document to be displayed and printer should the user choose.
            Process.Start("tester.docx");
        }

        //Tester button whihc called the Find and Replace function
        private void TestReplace(object sender, RoutedEventArgs e)
        {
            FindReplace("<Name>", TestInputText.Text);
        }
    }
}
