using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("zaz1");
            newData.Header = "1111";
            newData.Footer = null;

            app.Groups.IsModifyGroup();

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            //app.Groups.InitGroupSearch();

            app.Groups.Modify(oldData, newData);

           
            List<GroupData> newGroups = GroupData.GetAll();

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            

            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }

        }
    }
}
