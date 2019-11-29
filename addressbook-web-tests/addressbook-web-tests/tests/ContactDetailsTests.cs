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
            string fromForm = app.Contacts.GetContactInformationFromEditForm1(0);
            string fromDetails = app.Contacts.GetContactInformationFromDetailPage().FullName;
            //string formForm1 = app.Contacts.GetContactInformatoinFormEditForm1(0);
            //string formDetails = app.Contacts.GetContactInformatoinFormDetail();

            // verification
            //Assert.AreEqual(formForm1, formDetails);
            Assert.AreEqual(fromForm, fromDetails);


        }
    }
}
