using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected AutoItX3 autoItX3;
        protected string APPTITLE;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            this.autoItX3= manager.AutoItX3;
            APPTITLE = ApplicationManager.APPTITLE;
        }
    }
}