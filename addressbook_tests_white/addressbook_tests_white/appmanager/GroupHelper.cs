using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.InputDevices;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;
using System.Windows.Automation;



namespace addressbook_tests_white
{
    public class GroupHelper: HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string CONTACTGROUPSTITLE = "Group list";
        public static string DELETEGROUPWINTITLE = "Delete group";

        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialogue = OpenGroupDialogue();
           
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                });
            }
            CloseGroupDialogue(dialogue);
            return list;
        }

        //public void EnsureThereIsAtLeastTwoGroup()
        //{
        //    List<GroupData> list = new List<GroupData>();

        //    string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
        //        "GetItemCount", "#0", "");
        //    if (int.Parse(count) <= 1)
        //    {
        //        GroupData newGroup = new GroupData()
        //        {
        //            Name = "test1"
        //        };

        //        Add(newGroup);
        //    }

        //}

        public void Add(GroupData newGroup)
        {
            Window dialogue = OpenGroupDialogue();
            dialogue.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox = (TextBox) dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);

            
            //aux.Send("{ENTER}");
            CloseGroupDialogue(dialogue);

        }





        public void Remove(GroupData toBeRemoved)
        {
            Window dialogue = OpenGroupDialogue();
            Window dialogue1 = OpenGroupDialogue();

            //EnsureThereIsAtLeastTwoGroup();
            //SelectGroup(toBeRemoved); // выбирем элемент из корня
            //CloseDeleteGroupsDialogue(dialogue1);
            CloseGroupDialogue(dialogue);
        }



        //private void SelectGroup(GroupData id)
        //{
        //    string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", "#0", "");

        //    for (int i = 0; i < int.Parse(count); i++)
        //    {
        //        string item = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
        //        "GetText", "#0|#" + i, "");

        //        if (item == id.Name)
        //        {
        //            aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d5", "Select", "#0" + i, "");
        //            break;
        //        }
        //    }
        //}

        //private void CloseDeleteGroupsDialogue(Window dialogue1)
        //{
        //    dialogue1.Get<Button>("uxDeleteAddressButton").Click(); 

        //}

        private void CloseGroupDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxCloseAddressButton").Click();
        }

        public Window OpenGroupDialogue()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
        }
    }
}