using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void ContactInformationTest()
        {
            ContactData formTable = app.Contacts.GetContactInformatoinFormTable(0);
            ContactData formForm = app.Contacts.GetContactInformatoinFormEditForm(0);

            // verification
            Assert.AreEqual(formTable, formForm);
            Assert.AreEqual(formTable.Address, formForm.Address);
            Assert.AreEqual(formTable.AllPhones, formForm.AllPhones);
            Assert.AreEqual(formTable.AllEmails, formForm.AllEmails);

        }
    }
}