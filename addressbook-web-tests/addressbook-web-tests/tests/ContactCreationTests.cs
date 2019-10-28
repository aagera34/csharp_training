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
            contact.Middlename = "djdjd";
            contact.Nickname = "dsjf";
            contact.Title = "sdf";
            contact.Company = "sadfasd";
            contact.Address = "strit";
            contact.Home = "dsjfkldsaf";
            contact.Mobile = "dsa89787";
            contact.Email = "sadfdsaf@com.ru";
            contact.Work = "asdf";
            contact.Fax = "adf";
            contact.Email2 = "sadf@com.ru";
            contact.Email3 = "test@com.ru";
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
