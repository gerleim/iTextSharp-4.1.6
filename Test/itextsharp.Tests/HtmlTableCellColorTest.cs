namespace itextsharp.Tests
{
    using System;
    using System.IO;

    using FizzCode.Library.Core.Assembly;
    using FizzCode.Library.HtmlToPdf;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HtmlTableCellColorTest
    {
        [TestMethod]
        public void Test_Row()
        {
            Test("TableRowColor");
        }

        [TestMethod]
        public void Test_Cell()
        {
            Test("TableCellColor");
        }

        public static void Test(string fileName)
        {
            try
            {
                string pathToData = $"../../../TestInput/{fileName}.html";

                string path = Assembly.AssemblyPath + pathToData;

                string content = File.ReadAllText(path + pathToData);

                byte[] pdf = PdfGenerator.HtmlTpPdf(content);

                File.WriteAllBytes($"{fileName}.pdf", pdf);
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
