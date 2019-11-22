﻿using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }

            return groups;

        }
        public static IEnumerable<GroupData> GroupDataFormCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string [] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;

        }
        public static IEnumerable<GroupData> GroupDataFormXmlFile()
        {
            return (List<GroupData>)
             new XmlSerializer(typeof(List<GroupData>))
             .Deserialize(new StreamReader(@"groups.xml"));
            

        }

        public static IEnumerable<GroupData> GroupDataFormJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
               File.ReadAllText(@"groups.json"));
        }

        public static IEnumerable<GroupData> GroupDataFormExcelFile()
        {
            List<GroupData> groups = new List<GroupData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"groups.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                groups.Add(new GroupData()
                {
                    Name = range.Cells[i, 1].Value,
                    Header = range.Cells[i, 2].Value,
                    Footer = range.Cells[i, 3].Value,
                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return groups;

        }

        [Test, TestCaseSource("GroupDataFormJsonFile")]

        //[Test]

        public void GroupCreationTest(GroupData group)
    {
            //List<GroupData> groups = JsonConvert.DeserializeObject<List<GroupData>>(
            //   File.ReadAllText(@"groups.json"));

        List<GroupData> oldGroups = GroupData.GetAll();
           
            app.Groups.Create(group);

        Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

        List<GroupData> newGroups = GroupData.GetAll();
        oldGroups.Add(group);
        oldGroups.Sort();
        newGroups.Sort();
        Assert.AreEqual(oldGroups, newGroups);
    }

        [Test]

        public void TestDBConntctivity()
        {
            // DateTime start = DateTime.Now;
            // List<GroupData> fromUi = app.Groups.GetGroupList();
            // DateTime end = DateTime.Now;
            // System.Console.Out.WriteLine(end.Subtract(start));

            // start = DateTime.Now;
            // List<GroupData> fromDb = GroupData.GetAll();
            //end = DateTime.Now;
            // System.Console.Out.WriteLine(end.Subtract(start));

            foreach (ContactData contact in GroupData.GetAll()[0].GetContacts()){
                System.Console.Out.WriteLine(contact);
            }
        }





}
}

