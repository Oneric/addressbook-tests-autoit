using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void RemoveGroupTest()
        {
            //precondition
            if(app.Groups.GetGroupList().Count == 1)
            {
                app.Groups.CreateNewGroup(new GroupData() { Name = "Removal test group"});
            }
            //test
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.RemoveSelectedGroup(0);
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();

            //Assertion
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
            Assert.AreEqual(newGroups, oldGroups);
        }
    }
}
