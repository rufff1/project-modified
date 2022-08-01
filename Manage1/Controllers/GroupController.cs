using Core.Entities;
using Core.Helpers;
using DataAccess.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage1.Controller
{
    public class GroupController
    {

        private GroupRepositories _groupRepositories;

        public GroupController()
        {
            _groupRepositories = new GroupRepositories();
        }

        #region CreateGroup
        public void CreateGroup()
        {
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter Group Name:");
            string name = Console.ReadLine();
        MaxSize: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter Group Max Size:");
            string size = Console.ReadLine();

            int maxSize;
            bool result = int.TryParse(size, out maxSize);
            if (result)
            {
                Group group = new Group
                {
                    Name = name,
                    MaxSize = maxSize
                };
                var createdGroup = _groupRepositories.Create(group);
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"Name:{createdGroup.Name} is successfully created with max size - {createdGroup.MaxSize} ");
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please, Enter Correct Group Max Size...");
                goto MaxSize;
            }

        }
        #endregion

        #region UpdateGroup

        public void UpdateGroup()
        {
            var groups = _groupRepositories.GetAll();
            if (groups.Count > 0)
            {


                ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkBlue, " All groups:");
                foreach (var dbgroup in groups)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{dbgroup.Id}, Name:{dbgroup.Name}");
                }

            name: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter Group Id");
                string id = Console.ReadLine();
                int chosenId;
                bool result = int.TryParse(id, out chosenId);

                if (result)
                {
                    var group = _groupRepositories.Get(g => g.Id == chosenId);
                    if (group != null)
                    {

                        int oldSize = group.MaxSize;
                        string oldName=group.Name;  
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter new group name:");
                        string newName = Console.ReadLine();

                    size: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter new group size:");
                        string size = Console.ReadLine();


                        int maxSize;
                        result = int.TryParse(size, out maxSize);
                        if (result)
                        {
                            var newGroup = new Group
                            {
                                Id = group.Id,
                                Name = newName,
                                MaxSize = maxSize
                            };
                            _groupRepositories.Update(newGroup);
                            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"name:{oldName}, Max Size:{oldSize} is updated to Name:{newGroup.Name}, Max Size:{newGroup.MaxSize} ");

                        }
                        else
                        {
                            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please, Enter correct Group max size");
                            goto size;
                        }
                    }
                    else
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "this Group ID doesn't exist");
                   
                    }

                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please, Enter correct Group Id");
                    goto name;
                }
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "There are no any groups");

            }
        }
        #endregion

        #region DeleteGroup
        public void DeleteGroup()
        {
            var groups = _groupRepositories.GetAll();
            if (groups.Count > 0)
            {


                ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkBlue, "All group:");
                foreach (var dbgroup in groups)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{dbgroup.Id}, Name:{dbgroup.Name}");
                }

            name: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter Group Id:");
                string id = Console.ReadLine();
                int chosenId;
                var result = int.TryParse(id, out chosenId);
                var group = _groupRepositories.Get(g => g.Id == chosenId);

                if (group != null)
                {
                    string name = group.Name;
                    _groupRepositories.Delete(group);
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"{name} group is successfully deleted");
                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "This group doesn't exist");
                    goto name;

                }
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "There are no any groups");
            }
        }
        #endregion

        #region AllGroup

        public void AllGroup()
        {

            var groups = _groupRepositories.GetAll();
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "All Groups:");
            foreach (var group in groups)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"Group Name:{group.Name} , Max Size:{group.MaxSize}");
            }
        }
        #endregion

        #region GetGroupByName
        public void GetGroupByName()
        {
        name: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter group name");
            string name = Console.ReadLine();

            var group = _groupRepositories.Get(g => g.Name.ToLower() == name.ToLower());
            if (group != null)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"Name:{group.Name}, Max Size:{group.MaxSize}");
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "This group doesn't exist");
                goto name;
            }
        }
        #endregion

        #region Exit
        public void Exit()
        {

            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Thanks for using My App ");
        }
        #endregion




    }
}



