using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {
        public static string APPTITLE = "Free Address Book";
        private AutoItX3 autoItX3;
        private GroupHelper groupHelper;
        public ApplicationManager() 
        {
            autoItX3 = new AutoItX3();
            autoItX3.Run(@"F:\Source\AddressBook\AddressBook.exe", "", autoItX3.SW_SHOW);
            autoItX3.WinWait(APPTITLE);
            autoItX3.WinActivate(APPTITLE);
            autoItX3.WinWaitActive(APPTITLE);

            groupHelper = new GroupHelper(this);
        }
        public void Stop()
        {
            autoItX3.ControlClick(APPTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510");
        }
        public GroupHelper Groups { get 
            { 
                return groupHelper; 
            } 
        }
        public AutoItX3 AutoItX3 { get 
            { 
                return autoItX3; 
            } 
        }
    }
}
