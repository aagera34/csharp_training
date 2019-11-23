using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allDetailsForm;

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
                    return (CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        private string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return Regex.Replace(email, "[ -()]", "") + "\r\n";
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
       
        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

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
                    return CleanDetailFormUp(Firstname).Trim() + " " + (CleanDetailFormUp(Middlename) + "\r\n" + CleanDetailFormUp(Lastname) + CleanDetailFormUp(Nickname) + "\r\n"
                        + CleanDetailFormUp(Title) + "\r\n" + CleanDetailFormUp(Company) + "\r\n" + CleanDetailFormUp(Address) + "\r\n" + "\r\nH:" + " " + CleanDetailFormUp(HomePhone)
                        + "\r\nM:" + " " + CleanDetailFormUp((MobilePhone) + "\r\nW:" + " " + CleanDetailFormUp(WorkPhone) + "\r\nF:" + " " + CleanDetailFormUp(Fax) + "\r\n" + "\r\n" + CleanDetailFormUp(Email)
                        + "\r\n" + CleanDetailFormUp(Email2) + "\r\n" + CleanDetailFormUp(Email3) + "\r\nHomepage:\r\n" + CleanDetailFormUp(Homepage) + "\r\n\r\n\r\n"
                        + CleanDetailFormUp(Address2) + "\r\n" + "\r\nP:" + " " + CleanDetailFormUp(Phone2) + "\r\n" + "\r\n" + CleanDetailFormUp(Notes))).Trim();
                }
            }
            set
            {
                allDetailsForm = value;
            }
        }
        
        private string CleanDetailFormUp(string detailsform)
        {
            if (detailsform == null || detailsform == "")
            {
                return "";
            }

            return detailsform.Replace("-", "");
            //return detailsform;
            //return detailsform.Replace(" ", "").Replace("-", "").Replace("\r", "").Replace("\n", "");
        }

        //public string AllDetails
        //{
        //    get
        //    {
        //        if (allDetails != null)
        //        {
        //            return allDetails;
        //        }
        //        else
        //        {
        //            return (CleanDetailUp(Firstname) + CleanDetailUp(Lastname)).Trim() + (Address + AllEmails + AllPhones).Trim();
        //        }
        //    }
        //    set
        //    {
        //        allDetails = value;
        //    }
        //}

        //private string CleanDetailUp(string details)
        //{
        //    if (details == null || details == "")
        //    {
        //        return "";
        //    }
        //    return Regex.Replace(details, "[ -()]", "") + "\r\n";
        //}
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
         

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {

                return (from c in db.Contacts.Where(x=> x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }//закрывается база данных автоматически
        }
    }
}

