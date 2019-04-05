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
        }

        public void CreateDoc()
        {
            //Converting the resource data into Byte[]
            byte[] doc = Properties.Resources.CharacterSheetTestWord;

            MemoryStream ms = new MemoryStream(doc);

            FileStream f = new FileStream(@"template", FileMode.OpenOrCreate );
            
            ms.WriteTo(f);
            f.Close();
            ms.Close();

        }

        public void FindReplace2(string findText, string replaceText)
        {


            string executableLocation = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string fileLocation = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Resources/CharacterSheetTestWord.docx");

            var app = new Microsoft.Office.Interop.Word.Application();
            
            var doc = app.Documents.Open(fileLocation);

            var range = doc.Range();

            range.Find.Execute(FindText: findText, Replace: Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll, ReplaceWith: replaceText);

            
            var shapes = doc.Shapes;
            foreach(Microsoft.Office.Interop.Word.Shape shape in shapes)
            {
                string initialText = shape.TextFrame.TextRange.Text;
                string resultingText = initialText.Replace(findText, replaceText);
                shape.TextFrame.TextRange.Text = resultingText;
            }

            string saveLoc = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tester.docx");
            doc.SaveAs2(saveLoc);
            app = null;
            doc.Close();
            Process.Start("tester.docx");
            
            
            

        }

        public void FindAndReplace(Microsoft.Office.Interop.Word.Application fileOpen, object findText, object replaceWithText)
        {
            object matchCase = false;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            //execute find and replace
            fileOpen.Selection.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap, ref format, ref replaceWithText, ref replace,
                ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
        }


        private void TestReplace(object sender, RoutedEventArgs e)
        {

            //CreateDoc();
            
            
            FindReplace2("<Name>", "Woo2");
           
            
            //File.Open(fileLocation, FileMode.Open);
        }

        
    }
}
