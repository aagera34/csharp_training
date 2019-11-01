﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;



namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public bool acceptNextAlert { get; private set; }



        private string baseURL;
        public object newcontact1;

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToContactPage();

            GoToNewContactPage();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToContactPage();
            return this;
        }

        public ContactHelper Modify(ContactData newData)
        {
            manager.Navigator.GoToContactPage();

            SelectContact(0);
            InitContactModification(0);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToContactPage();
            return this;
        }



        public ContactHelper Remove(int v)
        {
            manager.Navigator.GoToHomePage();

            SelectContact(0);
            acceptNextAlert = true;
            RemoveContact();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            driver.FindElement(By.CssSelector("div.msgbox"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            ReturnToContactsPage();
            return this;
        }



        public ContactHelper ReturnToContactsPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        public void GoToContactPage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook");
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();

            //driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();

            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper GoToNewContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }
        private void chooseOkOnNextConfirmation()
        {
            throw new NotImplementedException();
        }

        public ContactHelper ReturnToContactPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {

            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("work"), contact.WorkPhone);
            //Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);

            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("17");
            driver.FindElement(By.XPath("//option[@value='17']")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("January");
            driver.FindElement(By.XPath("//option[@value='January']")).Click();

            Type(By.Name("byear"), contact.Byear);

            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText("15");
            driver.FindElement(By.XPath("(//option[@value='15'])[2]")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("January");
            driver.FindElement(By.XPath("//select[4]/option[2]")).Click();

            Type(By.Name("ayear"), contact.Ayear);
            Type(By.Name("address2"), contact.Address2);
            //Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);

            return this;
        }


        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

        private bool newIsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void InitContactSearch()
        {
            if (IsElementPresent(By.ClassName("center")))
            {
                return;
            }
            ContactData newData = new ContactData("hghh", "hhr");
            Create(new ContactData(newData));
        }
        private List<ContactData> contactCache = null;


        public List<ContactData> GetContactList()
        {

            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToContactPage();

                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[Name=entry]"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    //ContactData contact = new ContactData(cells[1].Text, cells[2].Text);
                    contactCache.Add(new ContactData(cells[1].Text, cells[2].Text));
                }
            }
            return new List<ContactData>(contactCache);
        }

        public ContactData GetContactInformatoinFormTable(int index)
        {
            manager.Navigator.GoToContactPage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));

            string lastName = cells[1].Text;
            string fistName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;
           

         return new ContactData(lastName, fistName)
            {
            Address = address,
            AllPhones = allPhones,
            AllEmails = allEmails,
            
           };


        }

        public ContactData GetContactInformatoinFormEditForm(int index)
        {
            manager.Navigator.GoToContactPage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(lastName, firstName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
    }
}
    }
