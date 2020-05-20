using System;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;

namespace Automation
{
    public class AutomationSession : IDisposable
    {   
        private const string winAppDriverUrl = "http://127.0.0.1:4723";            
        private WindowsDriver<WindowsElement> session;
        public WindowsDriver<WindowsElement> Session { get { return session; } }
                
        public AutomationSession()
        {
            session = CreateSession();
        }
                            
        /// <summary>
        /// Returns a session of WinAppDriver       
        /// </summary>
        public WindowsDriver<WindowsElement> CreateSession()
        {                        
            AppiumOptions options = new AppiumOptions();
            var userName = Environment.UserName;
            options.AddAdditionalCapability("app", $@"C:\Users\{userName}\AppData\Local\Programs\Microsoft VS Code\Code.exe");
            WindowsDriver<WindowsElement> vsCodeSession = new WindowsDriver<WindowsElement>(new Uri(winAppDriverUrl), options);

            vsCodeSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            return vsCodeSession;   
        }

        public void Dispose()
		{
			if (Session != null)
			{
				Session.Quit();             
			}
		}
                
    }
}
