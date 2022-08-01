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

         var groups = _groupRepositories.GetAll();

            if (groups.Count > 0)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter Student Name:");
                string name = Console.ReadLine();

                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter Student SurName:");
                string surname = Console.ReadLine();

                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter Student Age:");
                string age = Console.ReadLine();
                byte studentAge;
                bool result = byte.TryParse(age, out studentAge);

            groupalllist: ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkBlue, "All Group:");
                foreach (var group in groups)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{group.Id}, Name:{group.Name}");
                }

            id: groupname: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter Group Id:");
                string Id = Console.ReadLine();
                int id;

                result = int.TryParse(Id, out id);

                if (result != null)
                {
                    var group = _groupRepositories.Get(g => g.Id == id);

                    if (group != null)
                    {
                        if (group.MaxSize > group.CurrentSize)

                        {
                            var student = new Student
                            {
                                Name = name,
                                Surname = surname,
                                Age = studentAge,
                                group = group
                            };
                            group.CurrentSize++;
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
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "this group doesn't exist");
                        goto id;
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

            var groups = _groupRepositories.GetAll();
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkBlue, "All Group:");
            if (groups.Count > 0)
            {
                foreach (var group in groups)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, $"ID:{group.Id}, Name:{group.Name}");
                }
                var students = _studentRepositories.GetAll();
                if (_studentRepositories.GetAll().Count>0)
                {
                    foreach (var student in students)
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkBlue, "All student by group:" );
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, $" Id:{student.Id}, Name:{student.Name}");
                    }
                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "There are students no.");
                    
                }
            id: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter student Id");
                string id = Console.ReadLine();

                int studentid;
                bool result = int.TryParse(id, out studentid);
                var studentId = _studentRepositories.Get(s => s.Id == studentid);

                if (studentId != null)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "enter newName:");
                    string newName = Console.ReadLine();
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "enter newSurname:");
                    string newSurname = Console.ReadLine();
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "enter newAge:");
                    string Age = Console.ReadLine();
                    byte newage;
                    result = byte.TryParse(Age, out newage);
                groupname: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "enter new group name:");
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
                    goto id;
                }
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "There are no any groups");
            }
        }




        #endregion

        #region DeleteStudent
        public void DeleteStudent()
        {

            var students = _studentRepositories.GetAll();
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkBlue, "All Student:");

            if (students.Count > 0)
            {
                foreach (var student in students)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{student.Id}, Name:{student.Name}, Surname:{student.Surname}");
                }
            enterid: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter Student Id:");
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
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "There are no doesn't");
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
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, $"ID:{group.Id}  Name:{group.Name}");
            }
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter Group Id:");
            string groupId = Console.ReadLine();
            int id;
            bool result = int.TryParse(groupId, out id);
            var dbgroup = _groupRepositories.Get(g => g.Id == id);
            if (dbgroup != null)
            {
                var groupStudents = _studentRepositories.GetAll(s => s.group.Id == dbgroup.Id);


                if (groupStudents.Count != 0)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "All student off the group:");
                    foreach (var groupStudent in groupStudents)
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $" ID:{groupStudent.Id}, Name:{groupStudent.Name}, Surname:{groupStudent.Surname},Age:{groupStudent.Age}, ID:{groupStudent.Id}");

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
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $" Group Id:{group.Id} group.Name:{group.Name}");

            }
        Id: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "enter group id:");
            string groupId = Console.ReadLine();
            int id;
            bool result = int.TryParse(groupId, out id);
            if (result)
            {
                var dbgroup = _groupRepositories.Get(g => g.Id == id);
                if (dbgroup != null)
                {

                    var students = _studentRepositories.GetAll();
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkBlue, "All Students:");
                    foreach (var student in students)
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, $"ID:{student.Id} Name:{student.Name} Surname:{student.Surname}");
                    }
                enterid: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter student id:");
                    string studentid = Console.ReadLine();
                    int studentId;
                    result = int.TryParse(studentid, out studentId);
                    if (result)
                    {

                        var Student = _studentRepositories.Get(s => s.Id == id && s.group.Id == dbgroup.Id);

                        if (Student != null)
                        {

                            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, $" studentId:{Student.Id}studentName:{Student.Name}, studentSurname:{Student.Surname}, studentAge:{Student.Age}");
                        }
                        else
                        {
                            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "This student doesn't exist group");
                            goto enterid;
                        }
                    }
                    else
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "enter correct format student ID ");
                    }
                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "this group doesn't exist");
                    goto allgroup;
                }

            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Enter correct group format Id");
                goto Id;
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
