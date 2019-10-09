using System; 
using System.Text; 
using System.Text.RegularExpressions; 
using System.Threading; 
using NUnit.Framework; 
using OpenQA.Selenium; 
using OpenQA.Selenium.Firefox; 
using OpenQA.Selenium.Support.UI; 
 
 namespace WebAddressbookTests
 { 
   [TestFixture] 
    public class ContactCreation1Tests
 { 
     private IWebDriver driver; 
     private StringBuilder verificationErrors; 
     private string baseURL; 
     private bool acceptNextAlert = true; 
  
      [SetUp] 
      public void SetupTest()
     { 
        driver = new FirefoxDriver(); 
        baseURL = "http://localhost:8098/addressbook"; 
        verificationErrors = new StringBuilder();
      } 
         [TearDown] 
    public void TeardownTest()
    { 
         try 
       { 
    driver.Quit(); 
   } 
  catch (Exception) 
    { 
     // Ignore errors if unable to close the browser 
   } 
   Assert.AreEqual("", verificationErrors.ToString()); 
   } 
 
 
   [Test] 
 public void ContactCreation1Test()
 { 
  OpenHomePage(); 
  Login(new AccountData("admin", "secret")); 
  GoToNewContactPage(); 
  InitContactCreation(); 
  ContactData contact = new ContactData("aaa", "ddd");
            contact.Middlename = "lll";
            contact.Nickname = "ddd";
            contact.Title = "ff";
            contact.Company = "OOO fgf";
            contact.Address = "strit Staschki";
            contact.Home = "863555963";
            contact.Mobile = "89000000000";
            contact.Email = "test@test.com";
            contact.Work = "sd";
            contact.Fax = "sda44444";
            contact.Email2 = "adsdf@test.com";
            contact.Email3 = "adsdf22@test.com";
            contact.Homepage = "asd";
            contact.Bday = "";
            contact.Bmonth = "";
            contact.Byear = "1990";
            contact.Aday = "";
            contact.Amonth = "";
            contact.Ayear = "2012";
            contact.Address2 = "sadsad";
            contact.Phone2 = "79005000000";
            contact.Notes = "adssd"; 
 
 
  FillContactForm(contact); 
  SubmitContactCreation(); 
  ReturnToContactsPage(); 
 
 
    } 
  private void ReturnToContactsPage()
   { 
  driver.FindElement(By.LinkText("home")).Click(); 
  } 
 
 
   private void SubmitContactCreation()
   { 
  driver.FindElement(By.Name("submit")).Click(); 
  } 
 
 
  private void FillContactForm(ContactData contact)
      { 
            driver.FindElement(By.Name("firstname")).Click(); 
           driver.FindElement(By.Name("firstname")).Clear(); 
          driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname); 
         driver.FindElement(By.Name("middlename")).Click(); 
         driver.FindElement(By.Name("middlename")).Clear(); 
           driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename); 
           driver.FindElement(By.Name("lastname")).Click(); 
         driver.FindElement(By.Name("lastname")).Clear(); 
         driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname); 
         driver.FindElement(By.Name("nickname")).Click(); 
          driver.FindElement(By.Name("nickname")).Clear(); 
       driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname); 
         driver.FindElement(By.Name("title")).Click(); 
          driver.FindElement(By.Name("title")).Clear(); 
           driver.FindElement(By.Name("title")).SendKeys(contact.Title); 
           driver.FindElement(By.Name("company")).Click(); 
            driver.FindElement(By.Name("company")).Clear(); 
           driver.FindElement(By.Name("company")).SendKeys(contact.Company); 
           driver.FindElement(By.Name("address")).Click(); 
           driver.FindElement(By.Name("address")).Clear(); 
           driver.FindElement(By.Name("address")).SendKeys(contact.Address); 
            driver.FindElement(By.Name("home")).Click(); 
           driver.FindElement(By.Name("home")).Click(); 
           driver.FindElement(By.Name("home")).Clear(); 
            driver.FindElement(By.Name("home")).SendKeys(contact.Home); 
             driver.FindElement(By.Name("mobile")).Click(); 
             driver.FindElement(By.Name("mobile")).Clear(); 
            driver.FindElement(By.Name("mobile")).SendKeys(contact.Mobile); 
             driver.FindElement(By.Name("email")).Click(); 
             driver.FindElement(By.Name("email")).Clear(); 
             driver.FindElement(By.Name("email")).SendKeys(contact.Email); 
            driver.FindElement(By.Name("work")).Click(); 
            driver.FindElement(By.Name("work")).Clear(); 
           driver.FindElement(By.Name("work")).SendKeys(contact.Work); 
            driver.FindElement(By.Name("fax")).Click(); 
            driver.FindElement(By.Name("fax")).Clear(); 
            driver.FindElement(By.Name("fax")).SendKeys(contact.Fax); 
           driver.FindElement(By.Name("email2")).Click(); 
            driver.FindElement(By.Name("email2")).Clear(); 
             driver.FindElement(By.Name("email2")).SendKeys(contact.Email2); 
            driver.FindElement(By.Name("email3")).Click(); 
           driver.FindElement(By.Name("email2")).Click(); 
             driver.FindElement(By.Name("email3")).Click(); 
            driver.FindElement(By.Name("email3")).Click(); 
            driver.FindElement(By.Name("email3")).Clear(); 
             driver.FindElement(By.Name("email3")).SendKeys(contact.Email3); 
             driver.FindElement(By.Name("homepage")).Click(); 
             driver.FindElement(By.Name("homepage")).Clear(); 
             driver.FindElement(By.Name("homepage")).SendKeys(contact.Homepage); 
            driver.FindElement(By.Name("bday")).Click(); 
             new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("17"); 
             driver.FindElement(By.XPath("//option[@value='17']")).Click(); 
            driver.FindElement(By.Name("bmonth")).Click(); 
             new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("January"); 
            driver.FindElement(By.XPath("//option[@value='January']")).Click(); 
            driver.FindElement(By.Name("byear")).Click(); 
             driver.FindElement(By.Name("byear")).Clear(); 
             driver.FindElement(By.Name("byear")).SendKeys(contact.Byear); 
             driver.FindElement(By.Name("aday")).Click(); 
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText("15"); 
             driver.FindElement(By.XPath("(//option[@value='15'])[2]")).Click(); 
             driver.FindElement(By.Name("amonth")).Click(); 
             new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("January"); 
            driver.FindElement(By.XPath("//select[4]/option[2]")).Click(); 
             driver.FindElement(By.Name("ayear")).Click(); 
            driver.FindElement(By.Name("ayear")).Clear(); 
             driver.FindElement(By.Name("ayear")).SendKeys(contact.Ayear); 
             driver.FindElement(By.Name("new_group")).Click(); 
            driver.FindElement(By.XPath("//option[@value='[none]']")).Click(); 
             driver.FindElement(By.Name("theform")).Click(); 
             driver.FindElement(By.Name("address2")).Click(); 
             driver.FindElement(By.Name("address2")).Clear(); 
            driver.FindElement(By.Name("address2")).SendKeys(contact.Address2); 
            driver.FindElement(By.Name("phone2")).Click(); 
             driver.FindElement(By.Name("phone2")).Clear(); 
             driver.FindElement(By.Name("phone2")).SendKeys(contact.Phone2); 
            driver.FindElement(By.Name("notes")).Click(); 
            driver.FindElement(By.Name("notes")).Clear(); 
             driver.FindElement(By.Name("notes")).SendKeys(contact.Notes); 

 
        } 
        private void InitContactCreation()
         { 
             driver.FindElement(By.Name("home")).Click(); 
         } 
 
 
      private void GoToNewContactPage()
       { 
            driver.FindElement(By.LinkText("add new")).Click(); 
       } 
        private void OpenHomePage()
        { 
            driver.Navigate().GoToUrl(baseURL); 
       } 
       private void Login(AccountData account)
        { 
          driver.FindElement(By.Name("user")).Clear(); 
         driver.FindElement(By.Name("user")).SendKeys(account.Username); 
           driver.FindElement(By.Name("pass")).Click(); 
          driver.FindElement(By.Name("pass")).Clear(); 
           driver.FindElement(By.Name("pass")).SendKeys(account.Password); 
           driver.FindElement(By.XPath("//input[@value='Login']")).Click(); 
      } 
       private bool IsElementPresent(By by)
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
  } 
 } 

