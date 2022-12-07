using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Biopoolsengardens.Pages.SwimmingPondsPage
{

    [TestFixture]
    internal class Class1
    {
        [Test]
        public static void  TestSomething()
        {

            IWebDriver _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));


        }
        





    }
}
