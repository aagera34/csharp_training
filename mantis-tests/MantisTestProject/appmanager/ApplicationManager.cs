using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using static System.Net.WebRequestMethods;

namespace MantisTestProject
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
               

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
         driver = new FirefoxDriver();
         driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
         baseURL = "http://localhost:8098";
         Registration = new RegistrationHelper(this);

        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        
        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost:8098/mantisbt-2.22.1/login_page.php";
                app.Value = newInstance;
                
            }
            return app.Value;
        }
   
   

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
         }

        public RegistrationHelper Registration { get; set; }
    }
}
