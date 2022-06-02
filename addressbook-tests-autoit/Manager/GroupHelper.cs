using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string GROUPWINDELETETITLE = "Delete group";
        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }
        /// <summary>
        /// Получаем список групп
        /// </summary>
        /// <returns></returns>
        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            OpenGroupsDialogue();
            string count = autoItX3.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = autoItX3.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetText", "#0|#" + i, "");
                groups.Add(new GroupData()
                {
                    Name = item
                });
            }
            CloseGroupsDialogue();
            return groups;
        }
        /// <summary>
        /// Набор шагов добавления группы
        /// </summary>
        /// <param name="newGroup">Объект класса GroupData</param>
        internal void CreateNewGroup(GroupData newGroup)
        {
            OpenGroupsDialogue();
            autoItX3.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            autoItX3.Send(newGroup.Name);
            autoItX3.Send("{ENTER}");
            CloseGroupsDialogue();
        }
        /// <summary>
        /// Закрыть диалоговое окно групп
        /// </summary>
        private void CloseGroupsDialogue()
        {
            autoItX3.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }
        /// <summary>
        /// Открыть диалоговое окно групп
        /// </summary>
        private void OpenGroupsDialogue()
        {
            autoItX3.ControlClick(APPTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            autoItX3.WinWait(GROUPWINTITLE);
        }
        /// <summary>
        /// Набор шагов для удаления группы
        /// </summary>
        /// <param name="id">Идентификатор группы</param>
        public void RemoveSelectedGroup(int id)
        { 
            OpenGroupsDialogue();
            autoItX3.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Select", $"#0|#{ Convert.ToString(id) }", "");
            autoItX3.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            DeleteChoisedGroup();
            CloseGroupsDialogue();
        }
        /// <summary>
        /// Подтверждаем удаление выбранной группы
        /// </summary>
        private void DeleteChoisedGroup()
        {
            autoItX3.WinWait(GROUPWINDELETETITLE);
            autoItX3.ControlClick(GROUPWINDELETETITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            autoItX3.WinWait(GROUPWINTITLE);
        }
    }
}
