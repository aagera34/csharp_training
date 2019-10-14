using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    public class NavigationHelper:HelperBase
    {
        
        public string baseURL;
        public bool acceptNextAlert = true;


        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }   
        
        
        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook");
        }
        public void GoToGroupsPage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook");
        }
        public void GoToNewGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void GoToContactPage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook");
        }
        public void GoToNewContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        public void ReturnToContactPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }

       }
}
