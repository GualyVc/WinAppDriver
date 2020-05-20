using System;
using Xunit;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Interactions;

namespace Automation
{
    public class VSCodeTest : AutomationTestsBase
    {     
        [Fact]
        public void VSCodeThemeTest()
        {       
            var viewButton = WinAppDriver.Session.FindElementByName("View");            
            viewButton.Click();
            WinAppDriver.Session.Keyboard.PressKey(OpenQA.Selenium.Keys.ArrowDown);
            WinAppDriver.Session.Keyboard.PressKey(OpenQA.Selenium.Keys.Enter);

            var palette = WinAppDriver.Session.FindElementByName("Type the name of a command to run.");
            palette.Click();
            palette.SendKeys("Extensions: Install Extensions");
            WinAppDriver.Session.Keyboard.PressKey(OpenQA.Selenium.Keys.Enter);

            WinAppDriver.Session.Keyboard.SendKeys("NetBeans Light Theme");
            WinAppDriver.Session.Keyboard.PressKey(OpenQA.Selenium.Keys.Enter);

            var theme = WinAppDriver.Session.FindElementByName("NetBeans Light Theme");
            Assert.True(theme.Displayed);
            theme.Click();            
            WinAppDriver.Session.FindElementByName("Install").Click();

            palette = WinAppDriver.Session.FindElementByName("Select Color Theme");
            palette.Click();
            palette.SendKeys("NetBeans Light Theme");
            WinAppDriver.Session.Keyboard.PressKey(OpenQA.Selenium.Keys.Enter);   

            Assert.True(WinAppDriver.Session.FindElementByName("Manage").Displayed);         
        }
       
    }
}
