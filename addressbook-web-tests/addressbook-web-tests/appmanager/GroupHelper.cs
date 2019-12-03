﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        private object newgroups1;

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }


        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            GoToNewGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }


        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();

            GoToNewGroupsPage();
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;

        }

        public GroupHelper Modify(GroupData group, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            GoToNewGroupsPage();
            SelectGroup(group.Id);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;

        }
        public void IsModifyGroup()
        {
            if (IsElementPresent(By.ClassName("group")))
            {
                return;
            }

            Create(new GroupData("qqq"));
        }

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupsPage();
            GoToNewGroupsPage();
            SelectGroup(v);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            GoToNewGroupsPage();
            SelectGroup(group.Id);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }


        public bool EnsureThereHasGroup()

        {

            List<GroupData> groups = GroupData.GetAll();

            return groups.Count != 0;
        }



        public void GoToNewGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {

            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }
        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {

            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public GroupHelper SelectGroup(String id)
        {

            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }
        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Click();
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }

        }
        public bool IsHasGroups()
        {
            return HasElementsWithProperty(By.ClassName("group"));
        }
        public GroupHelper EnsureThereIsAtLeastOneGroup()
        {
            if (!IsHasGroups())
            {
                GroupData group = new GroupData("1rh3");
                group.Header = "1sf23";
                group.Footer = "12sf4";
                Create(group);
            }
            return this;
        }
        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public void InitGroupSearch()
        {
            if (IsElementPresent(By.ClassName("group")))
            {
                return;
            }
            Create(new GroupData("group"));

        }

        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")

                    });
                }
                string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                string[] parts = allGroupNames.Split('\n');
                int shift = groupCache.Count - parts.Length;
                for (int i = 0; i < groupCache.Count; i++)
                {
                    if (i < shift)
                    {
                        groupCache[i].Name = "";
                    }
                    else
                    {
                        groupCache[i].Name = parts[i - shift].Trim();
                    }

                }
                //return groupCache;
            }

            return new List<GroupData>(groupCache);
        }

        public int GetGroupCount()
        {
            manager.Navigator.GoToGroupsPage();
            GoToNewGroupsPage();
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }
        public int AddGroupToDb(GroupData group)
        {
            return group.AddGroup(group).GetValueOrDefault();
        }

        public int GetFreeGroup(ContactData contact)
        {
            List<GroupData> allGroups = GroupData.GetAll();

            foreach (GroupData g in allGroups)
            {
                bool groupHasElement = false;

                List<ContactData> contactsInGroup = g.GetContacts();
                foreach (ContactData c in contactsInGroup)
                {
                    if (c.Equals(contact))
                    {
                        groupHasElement = true;
                        break;
                    }
                }

                if (!groupHasElement)
                {
                    return int.Parse(g.Id);
                }

            };

            return -1;
        }

        public int AddContactToGroupDb(int contactId, int groupId)
        {
            GroupContactRelation gcr = new GroupContactRelation();
            return gcr.AddNewRelation(contactId, groupId);
        }
        public int AddGroupToDb(GroupData group)
        {
            return group.AddGroup(group).GetValueOrDefault();
        }
    }
}
       
    
