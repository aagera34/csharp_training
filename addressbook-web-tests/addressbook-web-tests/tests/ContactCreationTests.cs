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
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Lastname = GenerateRandomString(100),
                    Firstname = GenerateRandomString(100),
                    Middlename = GenerateRandomString(100),
                    Company = GenerateRandomString(100),
                    Address = GenerateRandomString(100),
                    HomePhone = GenerateRandomString(100),
                    MobilePhone = GenerateRandomString(100),
                    Email = GenerateRandomString(100),
                    WorkPhone = GenerateRandomString(100),
                    Fax = GenerateRandomString(100),
                    Email2 = GenerateRandomString(100),
                    Email3 = GenerateRandomString(100),
                 
                });
            }
            
            return contacts;

        }

        
        [Test, TestCaseSource("RandomContactDataProvider")]

        public void ContactCreationTest(ContactData contact)
        {
            
           List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

        }

    }
}
