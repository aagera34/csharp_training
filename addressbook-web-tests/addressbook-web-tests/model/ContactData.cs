using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;
using LinqToDB;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]

    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string fullname;
        private string allInformation;
        private string allPhonesFromForm;
        private string contentDetails;
        private string allPhonesFromDetailPage;
        private string allEmailsFromForm;
        

        public ContactData()
        {
        }

        public ContactData(ContactData newData)
        {
        }

        public ContactData(string lastname, string firstname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public ContactData(string fullName)
        {

        }
        

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        //[Column(Name = "middlename")]
        public string Middlename { get; set; }

        //[Column(Name = "nickname")]
        public string Nickname { get; set; }

        //[Column(Name = "title")]
        public string Title { get; set; }

        //[Column(Name = "company")]
        public string Company { get; set; }

        //[Column(Name = "address")]
        public string Address { get; set; }

        //[Column(Name = "home")]
        public string HomePhone { get; set; }

        //[Column(Name = "mobile")]
        public string MobilePhone { get; set; }

        //[Column(Name = "work")]
        public string WorkPhone { get; set; }

        //[Column(Name = "fax")]
        public string Fax { get; set; }

        //[Column(Name = "email")]
        public string Email { get; set; }

        //[Column(Name = "email2")]
        public string Email2 { get; set; }

        //[Column(Name = "email3")]
        public string Email3 { get; set; }

        //[Column(Name = "homepage")]
        public string Homepage { get; set; }

        //[Column(Name = "bday")]
        public string Bday { get; set; }

        //[Column(Name = "bmonth")]
        public string Bmonth { get; set; }

        //[Column(Name = "byear")]
        public string Byear { get; set; }

        //[Column(Name = "aday")]
        public string Aday { get; set; }

        //[Column(Name = "amonth")]
        public string Amonth { get; set; }

       // [Column(Name = "ayear")]
        public string Ayear { get; set; }

        //[Column(Name = "address2")]
        public string Address2 { get; set; }

        //[Column(Name = "phone2")]
        public string Phone2 { get; set; }

        //[Column(Name = "notes")]
        public string Notes { get; set; }

        public string FullName { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]

        public string Id { get; set; }
        

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return (Firstname + Lastname).GetHashCode();
        }
        
        public override string ToString()
        {
            return ("firstname=" + Firstname + "\nlactname=" + Lastname + "\nmiddlename=" + Middlename + "\ncompany=" + Company + 
                "\naddress" + Address + "\nhomePhone" + HomePhone + "\nmobilePhone" + MobilePhone + "\nemail" + Email + "\nworkPhone" 
                + WorkPhone + "\nfax" + Fax + "\nemail2" + Email2 + "\nemail3" + Email3);
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3) + "\r\n".Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }
        
        
        public string allDetailsForm;


        public string AllDetailsForm
        {
            get
            {
                if (allDetailsForm != null)
                {
                    return allDetailsForm;
                }
                else
                {
                    return (Lastname) + (Firstname) + (Address + AllPhones + AllEmails).Trim();
                }
            }
            set
            {
                allDetailsForm = value;
            }
        }

        private string CleanDetailFormUp(string detailsForm)
        {
            if (detailsForm == null || detailsForm == "")
            {
                return "";
            }
            return Regex.Replace(detailsForm, "[ -()'\r?\n\r?\n']", "");
            //	//+ "\r\n";
        }
    
        private string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return Regex.Replace(email, "[ -()]", "") + "\r\n";
        }

        public string AllEmailsFromForm
        {
            get
            {
                if (allEmailsFromForm != null)
                {
                    return allEmailsFromForm;
                }
                else
                {
                    return (CheckEmail(Email) + CheckEmail(Email2) + CheckEmail(Email3)).Trim();
                }
            }
            set
            {
                allEmailsFromForm = value;
            }
        }

        public string AllPhonesFromForm
        {
            get
            {
                if (allPhonesFromForm != null)
                {
                    return allPhonesFromForm;
                }
                else
                {
                    return (AddPhoneSumbolH(HomePhone) + AddPhoneSumbolM(MobilePhone) + AddPhoneSumbolW(WorkPhone));
                }
            }
            set
            {
                allPhonesFromForm = value;
            }
        }

        public string AllPhonesFromDetailPage
        {
            get
            {
                if (allPhonesFromDetailPage != null)
                {
                    return allPhonesFromDetailPage;
                }
                else
                {
                    return HomePhone + MobilePhone + WorkPhone;
                }
            }
            set
            {
                allPhonesFromDetailPage = value;
            }
        }
        
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllInformationFromForm
        {
            get
            {
                if (allInformation != null)
                {
                    return allInformation;
                }
                else
                {
                    return (CheckFullName(FullName) + CheckAddress(Address) + AllPhonesFromForm + AllEmailsFromForm);
                }
            }
            set
            {
                allInformation = value;
            }
        }

        public string AllInformationFromDetailPage
        {
            get
            {
                if (contentDetails != null)
                {
                    return contentDetails;
                }
                else
                {
                    return (FullName + Address + AllPhonesFromDetailPage + AllEmails);
                }
            }
            set
            {
                contentDetails = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

             

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            int compareResulL = Lastname.CompareTo(other.Lastname);

            if (compareResulL == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            else
            {
                return compareResulL;
            }
        }

        public string Fullname
        {
            get
            {
                if (fullname != null)
                {
                    return fullname.Trim();
                }
                else
                {
                    return (Firstname.Trim() + " " + Lastname.Trim());
                }
            }
            set
            {
                fullname = value;
            }
        }

        public string CheckFullName(string fullname)
        {
            if (fullname == null || fullname == "")
            {
                return "";
            }
            else
            {
                return (Firstname.Trim() + " " + Lastname.Trim() + "\r\n");
            }
        }

        public string CheckAddress(string address)
        {
            if (address == null || address == "")
            {
                return "";
            }
            else
            {
                return Address + "\r\n" + "\r\n";
            }
        }

       
        private string AddPhoneSumbolH(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return "H: " + phone + "\r\n";
        }

        private string AddPhoneSumbolM(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return "M: " + phone + "\r\n";
        }

        private string AddPhoneSumbolW(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return "W: " + phone + "\r\n" + "\r\n";
        }

  
        private string CheckEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
        }


        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {

                return (from c in db.Contacts.Where(x=> x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }//закрывается база данных автоматически
        }
        public List<ContactData> GetContact()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts
                        from gcr in db.GCR.Where(p => p.GroupId == Id && p.ContactId == c.Id && c.Deprecated == "0000-00-00 00:00:00")
                        select c).Distinct().ToList();
            }
        }
        public List<ContactData> GetContactsListWithGroup(string groupId)
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts from gcr in db.GCR.Where(p => p.GroupId == groupId && p.ContactId == c.Id && c.Deprecated == "0000-00-00 00:00:00") select c).Distinct().ToList();
            }
        }
        public int? AddContact(ContactData contact)
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return db.Contacts
                    .Value(c => c.Firstname, contact.Firstname)
                    .Value(c => c.Lastname, contact.Lastname)
                    .InsertWithInt32Identity();
            }
        }
    }
}

