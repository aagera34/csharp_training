using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Lastname = GenerateRandomString(100),
                    Firstname = GenerateRandomString(100),
                    Middlename = GenerateRandomString(100),
                    Company = GenerateRandomString(100),
                    Address = GenerateRandomString(100),
                    HomePhone = GenerateRandomString(100),
                    MobilePhone = GenerateRandomString(100),
                    Email = GenerateRandomString(100),
                    WorkPhone = GenerateRandomString(100),
                    Fax = GenerateRandomString(100),
                    Email2 = GenerateRandomString(100),
                    Email3 = GenerateRandomString(100),

                });
            }

            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFormFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contact.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactData(parts[0], parts[1])
                {
                    Middlename = parts[2],
                    Company = parts[3],
                    Address = parts[4],
                    HomePhone = parts[5],
                    MobilePhone = parts[6],
                    Email = parts[7],
                    WorkPhone = parts[8],
                    Fax = parts[9],
                    Email2 = parts[10],
                    Email3 = parts[11]

                });
            }

            return contacts;
        
        }
        public static IEnumerable<ContactData> ContactDataFormXmlFile()
        {
            return (List<ContactData>)
             new XmlSerializer(typeof(List<ContactData>))
             .Deserialize(new StreamReader(@"contacts.xml"));

        }

        public static IEnumerable<ContactData> ContactDataFormJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
               File.ReadAllText(@"contacts.json"));
        }


        [Test, TestCaseSource("ContactDataFormXmlFile")]

        public void ContactCreationTest(ContactData contact)
        {

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

        }

        [Test]

        public void TestDBConntctivity()
        {
            DateTime start = DateTime.Now;
            List<ContactData> fromUi = app.Contacts.GetContactList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            List<ContactData> fromDb = ContactData.GetAll();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }


    }
    }

