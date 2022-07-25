using Core.Entities;
using Core.Helpers;
using DataAccess.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage1.Controllers
{
    public class StudentController
    {
        private StudentRepositories _studentRepositories;
        private GroupRepositories _groupRepositories;

        public StudentController()
        {
            _studentRepositories = new StudentRepositories();
            _groupRepositories = new GroupRepositories();
        }


        #region CreateStudent
        public void CreateStudent()
        {

        groupalllist: var groups = _groupRepositories.GetAll();
            if (groups.Count != 0)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter Student Name:");
                string name = Console.ReadLine();

                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter Student SurName");
                string surname = Console.ReadLine();

                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter Student Age");
                string age = Console.ReadLine();
                byte studentAge;
                bool result = byte.TryParse(age, out studentAge);

                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "All Group");
                foreach (var gorup in groups)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, gorup.Name);
                }

            groupname: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter Group Name");
                string groupname = Console.ReadLine();



                var dbGroup = _groupRepositories.Get(g => g.Name.ToLower() == groupname.ToLower());
                if (dbGroup != null)
                {
                    if (dbGroup.MaxSize > dbGroup.CurrentSize)

                    {
                        var student = new Student
                        {
                            Name = name,
                            Surname = surname,
                            Age = studentAge,
                            group = dbGroup
                        };
                        dbGroup.CurrentSize++;
                        _studentRepositories.Create(student);
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"Name:{student.Name}, Surname:{student.Surname}, Age:{student.Age}, Group:{student.group.Name}");

                    }
                    else
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Group is full");
                        goto groupalllist;
                    }
                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Group doesn't exist in all group");
                    goto groupname;
                }



            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "This group doesn't exist");
            }





        }
        #endregion

        #region UpdateStudent
        public void UpdateStudent()
        {
            GetAllStudentByGroup();
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter student Id");
            string id = Console.ReadLine();

            int studentid;
            bool result = int.TryParse(id, out studentid);
            var studentId = _studentRepositories.Get(s => s.Id == studentid);

            if (studentId != null)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "enter newName");
                string newName = Console.ReadLine();
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "enter newSurname");
                string newSurname = Console.ReadLine();
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "enter newAge");
                string Age = Console.ReadLine();
                byte newage;
                result = byte.TryParse(Age, out newage);
                groupname: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "enter new group name");
                string newGroupName = Console.ReadLine();

                if (studentId.group.Name.ToLower() == newGroupName)
                {
                    studentId.Surname = newSurname;
                    studentId.Name = newName;
                    studentId.Age = newage;
                    _studentRepositories.Update(studentId);

                }
                else
                {
                    studentId.Surname = newSurname;
                    studentId.Name = newName;
                    studentId.Age = newage;
                    studentId.group.CurrentSize--;
                    studentId.group = _groupRepositories.Get(g => g.Name.ToLower() == newGroupName.ToLower());
                    if (studentId.group != null)
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"newName:{newName}, newSurname:{newSurname}, newAge:{newage} newGroupName:{newGroupName} successfully update. ");

                        studentId.group.CurrentSize++;
                        _studentRepositories.Update(studentId);
                    }
                    else
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "this group doesn't exist");
                        goto groupname;

                    }



                }
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "this student doesn't exist");
            }
        }




        #endregion

        #region DeleteStudent
        public void DeleteStudent()
        {
        enterid: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter Student Id");
            string Id = Console.ReadLine();

            int id;
            bool result = int.TryParse(Id, out id);

            if (result != null)
            {

                var student = _studentRepositories.Get(s => s.Id == id);
                if (student != null)
                {

                    student.group.CurrentSize--;
                    _studentRepositories.Delete(student);
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"id:{id} student is deleted");


                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "This student doesn't exist");
                }
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct Id");
                goto enterid;

            }


        }
        #endregion

        #region GetAllStudentByGroup
        public void GetAllStudentByGroup()
        {
            var groups = _groupRepositories.GetAll();
        allgrouplist: ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkBlue, "All group");
            foreach (var group in groups)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, group.Name);
            }
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter Group Name");
            string groupName = Console.ReadLine();

            var dbgroup = _groupRepositories.Get(g => g.Name.ToLower() == groupName.ToLower());
            if (dbgroup != null)
            {
                var groupStudents = _studentRepositories.GetAll(s => s.group.Id == dbgroup.Id);


                if (groupStudents.Count != 0)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "All student off the group");
                    foreach (var groupStudent in groupStudents)
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"Name:{groupStudent.Name}, Surname:{groupStudent.Surname},Age:{groupStudent.Age}, ID:{groupStudent.Id}");

                    }
                }

                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "empty group");
                    goto allgrouplist;
                }


            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "not Group in the Groups");
                goto allgrouplist;
            }



        }

        #endregion

        #region GetStudentByGroup
        public void GetStudentByGroup()
        {
            var groups = _groupRepositories.GetAll();
        allgroup: ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkBlue, "All group:");
            foreach (var group in groups)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, group.Name);

            }
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "enter group name");
            string groupName = Console.ReadLine();

            var dbgroup = _groupRepositories.Get(g => g.Name.ToLower() == groupName.ToLower());
            if (dbgroup != null)
            {
              enterid:  ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter student id");
                string studentid = Console.ReadLine();
                int id;
                bool resul = int.TryParse(studentid, out id);


                var Student = _studentRepositories.Get(s => s.Id == id && s.group.Id==dbgroup.Id);
                if (Student != null)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, $"studentName:{Student.Name}, studentSurname:{Student.Surname}, studentAge:{Student.Age}");
                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "This student doesn't exist group");
                    goto enterid;
                }
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "this group doesn't exist");
                goto allgroup;
            }
        }
        #endregion


        #region Exit
        public void Exit()
        {

            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Thanks for using My App ");
        }
        #endregion
    }
}
