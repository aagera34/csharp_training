using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinimalisticTelnet;



namespace mantis_tests
{
    public class JamesHelper : HelperBase
    {
        public JamesHelper(ApplicationManager manager) : base(manager) { }


        public void Add(AccountData account)
        {
            if (Verify(account)) 
            {
                return;
            }
            TelnetConnection telnet = LoginToJames();
            telnet.WriteLine("adduser " + account.Name + " " + account.Password);//add
            System.Console.Out.WriteLine(telnet.Read());//прочитали

        }
        public void Delete(AccountData account)
        {
            if (! Verify(account))
            {
                return;
            }
            TelnetConnection telnet = LoginToJames();
            telnet.WriteLine("deluser " + account.Name);//delete
            System.Console.Out.WriteLine(telnet.Read());//прочитали

        }

        

        public bool Verify(AccountData account)
        {
            TelnetConnection telnet = LoginToJames();
            telnet.WriteLine("verify" + account.Name);//verify
            String s = telnet.Read();
            System.Console.Out.WriteLine(s);//прочитали
            return ! s.Contains("does not exist");
        }

        private static TelnetConnection LoginToJames()
        {
            TelnetConnection telnet = new TelnetConnection("localhost", 4555);
            System.Console.Out.WriteLine(telnet.Read());//прочитали
            telnet.WriteLine("root");//login
            System.Console.Out.WriteLine(telnet.Read());//прочитали
            telnet.WriteLine("root");//password
            System.Console.Out.WriteLine(telnet.Read());//прочитали
            return telnet;
        }
    }
}
 