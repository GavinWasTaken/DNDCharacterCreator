using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

        public void CreatePDF()
        {
            //Converting the resource data into Byte[]
            byte[] PDF = Properties.Resources.DNDBlankCharacterSheetTest;

            MemoryStream ms = new MemoryStream(PDF);

            FileStream f = new FileStream("test.pdf", FileMode.OpenOrCreate );

            ms.WriteTo(f);
            f.Close();
            ms.Close();

            Process.Start("test.pdf");

            
        }

        public void FindReplace2(string docLoc, string findText, string replaceText)
        {
            var app = new Microsoft.Office.Interop.Word.Application();
            var doc = app.Documents.Open(docLoc);

            var range = doc.Range();

            range.Find.Execute(FindText: findText, Replace: Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll, ReplaceWith: replaceText);

            
            var shapes = doc.Shapes;
            foreach(Microsoft.Office.Interop.Word.Shape shape in shapes)
            {
                string initialText = shape.TextFrame.TextRange.Text;
                string resultingText = initialText.Replace(findText, replaceText);
                shape.TextFrame.TextRange.Text = resultingText;
            }

            doc.Save();
            doc.Close();

        }

        public void SearchTextBox(Microsoft.Office.Interop.Word.Document oDoc, string name, string newContent)
        {
            
            if(oDoc.Shapes.Count > 0)
            {
                foreach (Microsoft.Office.Interop.Word.Shape shape in oDoc.Shapes)
                    {
                    var initialText = shape.TextFrame.TextRange.Text;
                    var resultingText = initialText.Replace(name, newContent);
                    shape.TextFrame.TextRange.Text = resultingText;

                    //shape.TextFrame.TextRange.Text = newContent;
                    //shape.TextFrame.ContainingRange.Text = newContent;

                        return;
                    }
            }
            
        }

       //public void FindAndReplace()
       //{
       //    String src = "C:\\\\Users\\gavin\\Documents\\Dungeons & Dragons\\Dm Stuff\\Blank Character Sheet\\TableTestDoc.docx";
       //    String dest = "C://Users/gavin/Documents/Dungeons & Dragons/Dm Stuff/Blank Character Sheet/test.doc";
       //
       //    Microsoft.Office.Interop.Word.Application fileOpen = new Microsoft.Office.Interop.Word.Application();
       //    Microsoft.Office.Interop.Word.Document wordDoc = fileOpen.Documents.Open(src);
       //
       //    //SearchTextBox(wordDoc, "<Name>", "Testing");
       //
       //    wordDoc.Save();
       //    wordDoc.Close();
       //    //object oMissing = System.Reflection.Missing.Value;
       //    //
       //    //object savepoint = dest;
       //    //wordDoc.SaveAs2(ref savepoint);
       //    //wordDoc.Close(ref oMissing, ref oMissing, ref oMissing);
       //    //wordDoc = null;
       //    //fileOpen.Quit(ref oMissing, ref oMissing, ref oMissing);
       //    //fileOpen = null;
       //
       //
       //    //wordDoc.SaveAs2("C://Users/gavin/Documents/Dungeons & Dragons/Dm Stuff/Blank Character Sheet/testing.doc");
       //    //, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
       //
       //
       //
       //    //PdfReader reader = new PdfReader(src);
       //    //AcroFields pdffields = reader.AcroFields;
       //    //if (reader.HasUsageRights())
       //    //{
       //    //    reader.RemoveUsageRights();
       //    //
       //    //
       //    //
       //    //    reader.SelectPages("1-2");
       //    //    
       //    //    using (FileStream newFileStream = new FileStream("test", FileMode.Create))
       //    //    {
       //    //        PdfStamper stamper = new PdfStamper(reader, newFileStream);
       //    //        var fields = stamper.AcroFields;
       //    //        var fieldkeys = fields.Fields.Keys;
       //    //        foreach (String fieldKey in fieldkeys )
       //    //        {
       //    //            var value = reader.AcroFields.GetField(fieldKey);
       //    //            fields.SetField(fieldKey, value.Replace("adcd", "adcd"));
       //    //        }
       //    //        stamper.FormFlattening = true;
       //    //        stamper.Close();
       //    //        reader.Close();
       //    //    }
       //    //}
       //    // //File.Open("C:\\\\Users\\gavin\\Documents\\Dungeons & Dragons\\Dm Stuff\\Blank Character Sheet\\DNDBlankCharacterSheetTest.pdf", FileMode.Open);
       //    // //Process.Start("C:\\\\Users\\gavin\\Documents\\Dungeons & Dragons\\Dm Stuff\\Blank Character Sheet\\DNDBlankCharacterSheetTest.pdf");
       //    //
       //
       //    //File.Open("test.pdf", FileMode.Open);
       //
       //    //FileStream f = new FileStream("test.pdf", FileMode.OpenOrCreate);
       //    //byte[] PDF = Properties.Resources.DNDBlankCharacterSheetTest;
       //
       //
       //
       //    //PdfStream stream = new PdfStream(PDF);
       //    //PdfReader reader = new PdfReader(src);
       //    //PdfDictionary dict = reader.GetPageN(1);
       //    //PdfObject object = stream.GetDirectObject(PdfName.CONTENTS);
       //
       //    //string dd = new String(Encoding.UTF8.GetString(PDF).ToCharArray());
       //    //dd = dd.Replace("<Name>", TestInputText.Text);
       //
       //    //byte[] converted = Encoding.ASCII.GetBytes(dd);
       //    //MemoryStream convertedMS = new  MemoryStream(converted);
       //    //stream.WriteContent(convertedMS);           
       //    //byte[] finished = stream.GetBytes();
       //    //MemoryStream ms = new MemoryStream(finished);
       //
       //    //convertedMS.WriteTo(f);
       //    //f.Close();
       //
       //    //convertedMS.Close();
       //
       //
       //    //Process.Start("test.pdf");
       //}
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
            String src = "C:\\\\Users\\gavin\\Documents\\Dungeons & Dragons\\Dm Stuff\\Blank Character Sheet\\TableTestDoc.docx";
            String dest = "C://Users/gavin/Documents/Dungeons & Dragons/Dm Stuff/Blank Character Sheet/test.doc";
           
            Microsoft.Office.Interop.Word.Application fileOpen = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document wordDoc = fileOpen.Documents.Open(src);

            FindReplace2("C:\\\\Users\\gavin\\Documents\\Dungeons & Dragons\\Dm Stuff\\Blank Character Sheet\\Test.docx", "<Name>", "Woo");
            //FindAndReplace(wordDoc, "<Name>", "Test");
            //CreatePDF();
        }

        
    }
}
