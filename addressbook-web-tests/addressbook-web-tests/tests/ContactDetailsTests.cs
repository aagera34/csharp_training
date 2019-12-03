using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactDetailsTests : ContactTestBase

    {
        [Test]

        public void ContactDetailsTest()
        {

                ContactData fromDetaiPage = app.Contacts.GetContactInformationFromDetailPage();
                ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

                //verification

                Assert.AreEqual(fromDetaiPage.AllInformationFromDetailPage, fromForm.AllInformationFromForm);


         }

    }
}
