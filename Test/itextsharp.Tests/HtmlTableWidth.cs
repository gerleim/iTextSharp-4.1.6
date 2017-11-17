namespace itextsharp.Tests
{
    using System.IO;

    using FizzCode.Library.Core.Assembly;
    using FizzCode.Library.HtmlToPdf;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HtmlTableWidth
    {
        [TestMethod]
        public void Test_AllSet()
        {
            Test("TableWidthAllSet");
        }

        [TestMethod]
        public void Test_EmptyValues()
        {
            Test("TableWidthEmptyValues");
        }

        [TestMethod]
        public void Test_TMoreThan100()
        {
            Test("TableWidthMoreThan100");
        }

        private void Test(string fileName)
        {
            string pathToData = $"../../../TestInput/{fileName}.html";

            string path = Assembly.AssemblyPath + pathToData;

            string content = File.ReadAllText(path + pathToData);

            byte[] pdf = PdfGenerator.HtmlTpPdf(content);

            File.WriteAllBytes($"{fileName}.pdf", pdf);
        }
    }
}
