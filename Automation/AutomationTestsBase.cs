using System.IO;

namespace Automation
{
    /// <summary>
    /// Represents base class to implement a test class.
    /// </summary>
    public class AutomationTestsBase
    {
        /// <summary>
        /// Returns an instance of automation session        
        /// </summary>
        private static AutomationSession winAppDriver;        
        public static AutomationSession WinAppDriver { get { return winAppDriver ?? (winAppDriver = new AutomationSession()); } }
               
        public static void Disposes()
		{
			if (winAppDriver != null)
			{				
				winAppDriver.Dispose();
                winAppDriver = null;
			}
		}

    }
}