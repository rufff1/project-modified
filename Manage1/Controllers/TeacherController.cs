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
    public class TeacherController
    {
        private TeacherRepositories _teacherRepositories;
        private GroupRepositories _groupRepositories;


        public TeacherController()
        {
            _teacherRepositories = new TeacherRepositories();
            _groupRepositories = new GroupRepositories();
        }



        #region CreateTeacher
        public void CreateTeacher()
        {

            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter Teacher Name:");
            string name = Console.ReadLine();
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter Teacher Surname:");
            string surname = Console.ReadLine();
        age: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter Teacher Age");
            string Age = Console.ReadLine();
            byte age;
            bool result = byte.TryParse(Age, out age);
            if (result)
            {
                var teacher = new Teacher
                {
                    Name = name,
                    Surname = surname,
                    Age = age

                };
                var dbTeacher = _teacherRepositories.Create(teacher);
                if (dbTeacher != null)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"Teacher Is Successfull Create - Name:{teacher.Name}, Surname:{teacher.Surname}, Age:{teacher.Age}");

                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "something went wrong");
                }
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "please enter correct age");
                goto age;
            }




        }
        #endregion

        #region UpdateTeacher

        public void UpdateTeacher()
        {
            var teachers = _teacherRepositories.GetAll();
        all: ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkBlue, "All Teacher:");

            if (teachers.Count > 0)
            {



                foreach (var teacher1 in teachers)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, $"ID:{teacher1.Id}, Name:{teacher1.Name}, Surname:{teacher1.Surname}, Age:{teacher1.Age}");
                }

                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "Enter Teacher Id:");
                string Id = Console.ReadLine();
                int id;
                bool result = int.TryParse(Id, out id);
                if (result)
                {
                    var teacher = _teacherRepositories.Get(t => t.Id == id);
                    if (teacher != null)
                    {


                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter Teacher NewName:");
                        string newname = Console.ReadLine();
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter Teacher NewSurname:");
                        string newsurname = Console.ReadLine();
                    age: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter Teacher NewAge");
                        string age = Console.ReadLine();
                        byte newage;
                        result = byte.TryParse(age, out newage);
                        if (result)
                        {
                            teacher.Name = newname;
                            teacher.Surname = newsurname;
                            teacher.Age = newage;
                            _teacherRepositories.Update(teacher);
                            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"NewName:{newname}, NewSurname:{newsurname}, NewAge{newage} teacher is update.");
                        }
                        else
                        {
                            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "please enter correct age");
                            goto age;
                        }
                    }
                    else
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "This teacherId doesn't exist");
                    }

                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Teacher empty");
                    goto all;

                }

            }
        }

        #endregion

        #region DeleteTeacher
        public void DeleteTeacher()
        {
            var teachers = _teacherRepositories.GetAll();
        enterid: ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkBlue, "All Teacher:");
            if (teachers.Count > 0)
            {
                foreach (var teacher1 in teachers)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, $"ID:{teacher1.Id}, Name:{teacher1.Name}, Surname:{teacher1.Surname}, Age:{teacher1.Age}");
                }
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter Teacher Id:");
                string Id = Console.ReadLine();

                int id;
                bool result = int.TryParse(Id, out id);

                if (result != null)
                {

                    var teacher = _teacherRepositories.Get(t => t.Id == id);
                    if (teacher != null)
                    {


                        _teacherRepositories.Delete(teacher);
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"id:{id} Name:{teacher.Name} teacher is deleted");


                    }
                    else
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "This teacher doesn't exist");
                        goto enterid;
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
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "there are no any teacher");
            }

        }
        #endregion

        #region GetAll
        public void GetAll()
        {
            var teachers = _teacherRepositories.GetAll();
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "All Teacher:");
            foreach (var teacher in teachers)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"Teacher Id:{teacher.Id} , Teacher Name:{teacher.Name} , Teacher Surname:{teacher.Surname} , Teacher Age:{teacher.Age}");
            }

        }


        #endregion

        #region AddGroupToTeacher

        public void AddGroupToTeacher()
        {
            var groups = _groupRepositories.GetAll();
            if (groups.Count > 0)
            {
                var teachers = _teacherRepositories.GetAll();
                if (teachers.Count > 0)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "All teachers list");

                    foreach (var teacher in teachers)
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"Id - {teacher.Id}, Fullname - {teacher.Name} {teacher.Surname}");
                    }

                Id: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter teacher id:");
                    string id = Console.ReadLine();

                    int teacherId;
                    var result = int.TryParse(id, out teacherId);

                    if (result)
                    {
                        var teacher = _teacherRepositories.Get(t => t.Id == teacherId);
                        if (teacher != null)
                        {
                            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "All groups list");

                            foreach (var group in groups)
                            {
                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, $"Id - {group.Id}, Name - {group.Name}");
                            }

                        GroupId: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter group id:");
                            string groupid = Console.ReadLine();

                            int groupId;
                            result = int.TryParse(groupid, out groupId);
                            if (result)
                            {
                                var group = _groupRepositories.Get(g => g.Id == groupId);
                                if (group != null)
                                {
                                    if (group.Teacher == null)
                                    {
                                        teacher.Groups.Add(group);
                                        group.Teacher = teacher;
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"{group.Name} is successfully added to {teacher.Name}");
                                    }
                                    else
                                    {
                                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, $"This group has already teacher - {group.Teacher.Name} {group.Teacher.Surname}");
                                    }
                                }
                                else
                                {
                                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Group doesn't exist with this id");
                                    goto GroupId;
                                }
                            }
                            else
                            {
                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please, enter id in correct format");
                                goto GroupId;
                            }
                        }
                        else
                        {
                            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Teacher doesn't exist with this id");
                            goto Id;
                        }
                    }
                    else
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please, enter id in correct format");
                        goto Id;
                    }
                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "There is no any teacher");
                }
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "You must create a group before adding group to teacher");
            }


        }



        #endregion

        #region GetAllGroupsToTeacher

        public void GetAllGroupsToTeacher()
        {

            var teachers = _teacherRepositories.GetAll();
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkBlue, "All Teacher:");
            if (teachers.Count > 0)
            {
                foreach (var teacher in teachers)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{teacher.Id} Full Name:{teacher.Name} {teacher.Surname}");
                }

                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Enter Teacher Id:");
                string id = Console.ReadLine();
                int teacherId;
               bool result=int.TryParse(id, out teacherId);
                if (result)
                {
                    var teacher=_teacherRepositories.Get(t=> t.Id==teacherId);
                    if (teacher!=null)
                    {
                        var groups = _groupRepositories.GetAll(g => g.Teacher!=null ? g.Teacher.Id == teacher.Id : false);
                        if (groups.Count>0)
                        {
                            ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkBlue, "The groups of teaccher:");
                            foreach (var group in groups)
                            {
                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"ID:{group.Id} Name:{group.Name}");
                            }
                        }
                        else
                        {
                            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Teacher has not  group");
                        }
                    }
                    else
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "This teacher doesn't exist with this id");
                    }
                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "This  ID in correct format");
                }

            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "There is no any teacher");
            }
        }

        #endregion

        #region Exit
        public void Exit()
        {

            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "Thanks for using My App ");
        }
        #endregion






    }





}
