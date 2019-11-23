using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]

        public void ContactModificationTest()

        {
           
            ContactData newData = new ContactData("zz", "rrr");
            newData.Middlename = null;
            newData.Nickname = null;
            newData.Title = null;
            newData.Company = null;
            newData.Address = null;
            newData.HomePhone = null;
            newData.MobilePhone = null;
            newData.Email = null;
            newData.WorkPhone = null;
            newData.Fax = null;
            newData.Email2 = null;
            newData.Email3 = null;
            newData.Homepage = null;
            newData.Bday = null;
            newData.Bmonth = null;
            newData.Byear = null;
            newData.Aday = null;
            newData.Amonth = null;
            newData.Ayear = null;
            newData.Address2 = null;
            newData.Phone2 = null;
            newData.Notes = null;

            app.Contacts.InitContactSearch();

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldContact = oldContacts[0];

            app.Contacts.Modify(oldContact, newData);

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();

            //Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldContact.Id)
                {
                    Assert.AreEqual(contact.Id, oldContact.Id);
                    
                }
            }
        }
    }
}

