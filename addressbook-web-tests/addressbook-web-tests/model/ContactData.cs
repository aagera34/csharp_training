﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
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
                
        //public string Firstname
        //{
        //    get
        //    {
        //        if (firstname == null || firstname == "")
        //            //(Firstname != null)
        //        {
        //            return "";
        //        }
        //        else
        //        {
        //            return Firstname;
        //        }
        //    }
            
        //}

        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public string Middlename { get; set; }

        public string Nickname { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }
        
        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Homepage { get; set; }

        public string Bday { get; set; }

        public string Bmonth { get; set; }

        public string Byear { get; set; }

        public string Aday { get; set; }

        public string Amonth { get; set; }

        public string Ayear { get; set; }

        public string Address2 { get; set; }

        public string Phone2 { get; set; }

        public string Notes { get; set; }

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

        //public override string ToString()
        //{
        //    return (Firstname + Lastname);
        //}
        public override string ToString()
        {
            return ("firstname=" + Firstname + "\nlactname=" + Lastname + "\nmiddlename=" + Middlename + "\ncompany=" + Company + 
                "\naddress" + Address + "\nhomePhone" + HomePhone + "\nmobilePhone" + MobilePhone + "\nemail" + Email + "\nworkPhone" 
                + WorkPhone + "\nfax" + Fax + "\nemail2" + Email2 + "\nemail3" + Email3);
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
    }
}

