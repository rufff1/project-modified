using Core.Constants;
using Core.Entities;
using Core.Helpers;
using DataAccess.Implementations;
using Manage1.Controller;
using Manage1.Controllers;
using System;
namespace Manage1
{
    public class Manage1
    {

        static void Main()
        {


            GroupController _groupController = new GroupController();
            StudentController _studentController = new StudentController();



            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "Welcome My First App...");
            Console.WriteLine("--------------------------------------------------");



            while (true)
            {


                Mainmenu: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Main Menu:");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Group Menu - 1");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Student Menu - 2");

                Console.WriteLine("--------------------------------------------------");

                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Select Options:");
                string number = Console.ReadLine();

                int selectedNumber;
                bool result = int.TryParse(number, out selectedNumber);

                if (result)
                {
                    if (selectedNumber == 1)
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "1 - Create Group");
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update Group");
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "3 - Delete Group");
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "4 - All Group");
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "5 - Get Group By Name");
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "6 - Back Main Menu");
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "0 - Exit");
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Select Options:");
                        number = Console.ReadLine();


                        result = int.TryParse(number, out selectedNumber);
                        if (selectedNumber >= 0 && selectedNumber <= 6)
                        {
                            switch (selectedNumber)
                            {

                                case (int)GroupOptions.CreateGroup:
                                    _groupController.CreateGroup();
                                    break;
                                case (int)GroupOptions.UpdateGroup:
                                    _groupController.UpdateGroup();
                                    break;
                                case (int)GroupOptions.DeleteGroup:
                                    _groupController.DeleteGroup();
                                    break;
                                case (int)GroupOptions.AllGroup:
                                    _groupController.AllGroup();
                                    break;
                                case (int)GroupOptions.GetGroupByName:
                                    _groupController.GetGroupByName();
                                    break;
                                case (int)GroupOptions.Exit:
                                    _groupController.Exit();
                                    return;
                                case (int)GroupOptions.BackMainMenu:
                                    goto Mainmenu;
                                    break;

                            }
                        }
                        else
                        {
                            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please enter correct number");

                        }
                    }
                    else if (selectedNumber == 2)
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "1 - Create Student");
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update Student");
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "3 - Delete Student");
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "4 - Get All Student By Group");
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "5 - Get Student By Group");
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "6 - Back Main Menu");
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "0 - Exit");
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Select Options:");
                        number = Console.ReadLine();


                        result = int.TryParse(number, out selectedNumber);
                        if (selectedNumber >= 0 && selectedNumber <= 6)
                        {
                            switch (selectedNumber)
                            {

                                case (int)StudentOptions.UpdateStudent:
                                    _studentController.UpdateStudent();
                                    break;
                                case (int)StudentOptions.DeleteStudent:
                                    _studentController.DeleteStudent();
                                    break;
                                case (int)StudentOptions.GetAllStudentByGroup:
                                    _studentController.GetAllStudentByGroup();
                                    break;
                                case (int)StudentOptions.GetStudentByGroup:
                                    _studentController.GetStudentByGroup();
                                    break;
                                case (int)StudentOptions.Exit:
                                    _studentController.Exit();
                                    return;
                                    case (int)StudentOptions.BackMainMenu:
                                    goto Mainmenu;
                                    break;

                            }
                        }
                        else
                        {
                            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "please enter correct number");
                        }
                    }
                    else
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please, Select Correct Options...");
                    }
                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please, Select Correct Options...");
                }



            }




        }
    }
}