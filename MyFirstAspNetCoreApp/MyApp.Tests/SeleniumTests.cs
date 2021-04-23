using MyFirstAspNetCoreApp;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyApp.Tests
{
    public class SeleniumTests
    {
        [Fact]
        public void H1ElementIsRemovedFromPrivacyPage()
        {
            var serverFactory = new SeleniumServerFactory<Startup>();

            var options = new ChromeOptions();
            options.AcceptInsecureCertificates = true;
            options.AddArguments("--headless");
            
            var webDriver = new ChromeDriver(options);
            webDriver.Navigate().GoToUrl(serverFactory.RootUri + "/Home/Privacy");
            Assert.Throws<NoSuchElementException>(() =>  webDriver.FindElementByTagName("h1"));

        }
    }
}
