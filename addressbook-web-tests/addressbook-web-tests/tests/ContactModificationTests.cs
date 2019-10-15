using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]

        public void ContactModificationTest()

        {
            ContactData newData = new ContactData("zzz", "rrrr");
            newData.Middlename = "lsl";
            newData.Nickname = "alsl";
            newData.Title = "sdf";
            newData.Company = "sfds";
            newData.Address = "sdfdsa";
            newData.Home = "aaa";
            newData.Mobile = "ret";
            newData.Email = "buo@com";
            newData.Work = "sfd16456";
            newData.Fax = "5656456454";
            newData.Email2 = "buo1@com";
            newData.Email3 = "buo2@com";
            newData.Homepage = "78978978";
            newData.Bday = "";
            newData.Bmonth = "";
            newData.Byear = "2000";
            newData.Aday = "";
            newData.Amonth = "";
            newData.Ayear = "2012";
            newData.Address2 = "hgfghgfh";
            newData.Phone2 = "545456456456";
            newData.Notes = "5656456";

            app.Contacts.Modify(newData);
        }
    }
}

