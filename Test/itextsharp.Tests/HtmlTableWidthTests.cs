﻿namespace itextsharp.Tests
{
    using System;
    using System.IO;

    using FizzCode.Library.Core.Assembly;
    using FizzCode.Library.HtmlToPdf;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HtmlTableWidthTests
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
        public void Test_MoreThan100()
        {
            Test("TableWidthMoreThan100");
        }

        [TestMethod]
        public void Test_MoreThan100AndEmptyValues()
        {
            Test("TableWidthMoreThan100AndEmptyValues");
        }

        [TestMethod]
        public void Test_AllSet_Span()
        {
            Test("TableWidthAllSet_Span");
        }

        [TestMethod]
        public void Test_InsideTable_Span()
        {
            Test("TableWidthInsideTable_Span");
        }

        [TestMethod]
        public void Test_InsideTable_Span_2()
        {
            Test("TableWidthInsideTable_Span_2");
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
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
