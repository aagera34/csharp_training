using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
            [Test]
        public void ContactCreationTest()
        {
            
           ContactData contact = new ContactData("aaaa", "ddd");
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

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");
            contact.Middlename = "";
            contact.Nickname = "";
            contact.Title = "";
            contact.Company = "";
            contact.Address = "";
            contact.Home = "";
            contact.Mobile = "";
            contact.Email = "";
            contact.Work = "";
            contact.Fax = "";
            contact.Email2 = "";
            contact.Email3 = "";
            contact.Homepage = "";
            contact.Bday = "";
            contact.Bmonth = "";
            contact.Byear = "";
            contact.Aday = "";
            contact.Amonth = "";
            contact.Ayear = "";
            contact.Address2 = "";
            contact.Phone2 = "";
            contact.Notes = "";

            app.Contacts.Create(contact);

        }
    }
}
