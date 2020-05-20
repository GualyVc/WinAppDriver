using System;
using Xunit;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;

namespace Automation
{    
    public class DemoTests
    {           
        [Fact]
        public void NotePadTest()
        {   
            //Testing Classic Windows Application: NotePad

            //Setup options for NotePad
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("app", @"C:\Windows\System32\notepad.exe");
            options.AddAdditionalCapability("appArguments", @"MyTestFile.txt");
            options.AddAdditionalCapability("appWorkingDir", @"C:\MyTestFolder\");   

            //Create WinAppDriver session 
            var NotePadSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);

            //Use the session to control the application to write some text          
            NotePadSession.FindElementByClassName("Edit").SendKeys("Adding some text");          
            System.Threading.Thread.Sleep(3000);   //Sleep of 3s to see text added

            NotePadSession.FindElementByName("Edit").Click();                       
            NotePadSession.FindElementByAccessibilityId("25").Click();
            NotePadSession.Keyboard.PressKey(OpenQA.Selenium.Keys.Delete);
            
            NotePadSession.FindElementByClassName("Edit").SendKeys("This text is added using an automated test");  
        }
        
        [Fact]
        public void AlarmsAndClockTest()
        {                        
            //Testing Universal Windows Platform Application: Alarms & Clock app

            //Setup options for Alarms & Clock app
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("app", "Microsoft.WindowsAlarms_8wekyb3d8bbwe!App");

            //Create WinAppDriver session
            var AlarmClockSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);

            //Use the session to control the application to add new alarm           
            AlarmClockSession.FindElementByAccessibilityId("AddAlarmButton").Click();
            AlarmClockSession.FindElementByAccessibilityId("AlarmNameTextBox").Clear();            
            AlarmClockSession.FindElementByAccessibilityId("AlarmNameTextBox").SendKeys("Automated alarm test");

            AlarmClockSession.FindElementByAccessibilityId("HourSelector").FindElementByName("9").Click();
           
            AlarmClockSession.FindElementByAccessibilityId("AlarmRepeatsToggleButton").Click();  
            AlarmClockSession.FindElementByName("Monday").Click();  
            AlarmClockSession.FindElementByName("Wednesday").Click();
            AlarmClockSession.FindElementByName("Friday").Click();
            AlarmClockSession.FindElementByName("Close").Click();
            AlarmClockSession.FindElementByName("Save").Click();

            Assert.True(AlarmClockSession.FindElementByName("Automated alarm test, 9:00 AM, Monday, Wednesday, Friday, On").Displayed);
        }

        [Fact]
        public void VSCodeMenuBarTest()
        {           
            //Universal Windows Platform Application - Visual Studio Code
            
            //Setup options for VSCode
            AppiumOptions options = new AppiumOptions();
            var userName = Environment.UserName;
            options.AddAdditionalCapability("app", $@"C:\Users\{userName}\AppData\Local\Programs\Microsoft VS Code\Code.exe");
            var vsCodeSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
            
            //Wait for VSCode
            vsCodeSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            
            //Open and close menu elements
            var file = vsCodeSession.FindElementByName("File");
            Assert.NotNull(file);
            Assert.True(file.Displayed);
            file.Click();

            System.Threading.Thread.Sleep(1000);
            vsCodeSession.Keyboard.PressKey(OpenQA.Selenium.Keys.Escape);
            
            var edit = vsCodeSession.FindElementByName("Edit");
            Assert.NotNull(edit);
            Assert.True(edit.Displayed);
            edit.Click();

            System.Threading.Thread.Sleep(1000);
            vsCodeSession.Keyboard.PressKey(OpenQA.Selenium.Keys.Escape);

            var selection = vsCodeSession.FindElementByName("Selection");
            Assert.NotNull(selection);
            Assert.True(selection.Displayed);
            selection.Click();

            System.Threading.Thread.Sleep(1000);
            vsCodeSession.Keyboard.PressKey(OpenQA.Selenium.Keys.Escape);

            var view = vsCodeSession.FindElementByName("View");
            Assert.NotNull(view);
            Assert.True(view.Displayed);
            view.Click();

            System.Threading.Thread.Sleep(1000);
            vsCodeSession.Keyboard.PressKey(OpenQA.Selenium.Keys.Escape);

            var go = vsCodeSession.FindElementByName("Go");
            Assert.NotNull(go);
            Assert.True(go.Displayed);
            go.Click();

            System.Threading.Thread.Sleep(1000);
            vsCodeSession.Keyboard.PressKey(OpenQA.Selenium.Keys.Escape);

            var run = vsCodeSession.FindElementByName("Run");
            Assert.NotNull(run);
            Assert.True(run.Displayed);
            run.Click();

            System.Threading.Thread.Sleep(1000);
            vsCodeSession.Keyboard.PressKey(OpenQA.Selenium.Keys.Escape);

            var terminal = vsCodeSession.FindElementByName("Terminal");
            Assert.NotNull(terminal);
            Assert.True(terminal.Displayed);
            terminal.Click();

            System.Threading.Thread.Sleep(1000);
            vsCodeSession.Keyboard.PressKey(OpenQA.Selenium.Keys.Escape);

            var help = vsCodeSession.FindElementByName("Help");
            Assert.NotNull(help);
            Assert.True(help.Displayed);
            help.Click();

            System.Threading.Thread.Sleep(1000);
            vsCodeSession.Keyboard.PressKey(OpenQA.Selenium.Keys.Escape);

            vsCodeSession.Quit();
        }

    }
}