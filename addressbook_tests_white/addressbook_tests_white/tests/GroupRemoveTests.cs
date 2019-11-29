using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupRemoveTests : TestBase
    {
        [Test]

        public void TestGroupRemove()
        {
            app.Groups.OpenGroupDialogue();
            //app.Groups.EnsureThereIsAtLeastTwoGroup();
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData toBeRemoved = oldGroups[1];

            app.Groups.Remove(toBeRemoved);

           
            List<GroupData> newGroups = app.Groups.GetGroupList();
            
            oldGroups.RemoveAt(1);
            oldGroups.Sort();
            newGroups.Sort();


            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
