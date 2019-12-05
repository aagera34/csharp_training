using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    class AddingContactToGroupTests: AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            var manager = app.Groups.GetManager();
            manager.Navigator.GoToGroupsPage();
            app.Groups.EnsureThereIsAtLeastOneGroup();
            manager.Navigator.GoToHomePage();
            app.Contacts.EnsureThereIsAtLeastOneContact();

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();

            bool canAddToGroup = app.Contacts.EnsureThereContactAddTheGroup(contact, group);


            if (canAddToGroup)
            {
                app.Contacts.AddContactToGroup(contact, group);

            }
            else
            {
                contact.Firstname = "a1aa";
                contact.Lastname = "bb1b";
                app.Contacts.Create(contact);

                app.Contacts.AddContactToGroup(contact, group);

            }

            System.Threading.Thread.Sleep(100);
            List<ContactData> newList = group.GetContacts();

            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }

    }
}
