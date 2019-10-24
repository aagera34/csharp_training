using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
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
            newData.Home = null;
            newData.Mobile = null;
            newData.Email = null;
            newData.Work = null;
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

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.InitContactSearch();
            app.Contacts.Modify(0, newData);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

