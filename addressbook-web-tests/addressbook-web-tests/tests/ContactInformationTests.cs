﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : ContactTestBase
    {
        [Test]
        public void ContactInformationTest()
        {

            ContactData fromDetailPage = app.Contacts.GetContactInformationFromDetailPage();
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            //ContactData formTable = app.Contacts.GetContactInformatoinFormTable(0);
            //ContactData formForm = app.Contacts.GetContactInformatoinFormEditForm(0);

            // verification
            //Assert.AreEqual(formTable, formForm);
            //Assert.AreEqual(formTable.Address, formForm.Address);
            //Assert.AreEqual(formTable.AllPhones, formForm.AllPhones);
            //Assert.AreEqual(formTable.AllEmails, formForm.AllEmails);
            Assert.AreEqual(fromDetailPage.AllInformationFromDetailPage, fromForm.AllInformationFromForm);
        }
    }
}