using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
namespace DNDCharacterCreator
{
    class Functions
    {
        public void FindReplace2(string docLoc, string findText, string replaceText)
        {
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = app.Documents.Open(docLoc);

            Microsoft.Office.Interop.Word.Range range = doc.Range();

            range.Find.Execute(FindText: findText, Replace: Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll, ReplaceWith: replaceText);

            
            var shapes = doc.Shapes;
            foreach (Shape shape in shapes)
            {

            }
        }
    }
}
