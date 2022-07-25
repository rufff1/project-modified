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
            AdminController _adminController = new AdminController();







        Authentication: var admin = _adminController.Authenticate();


            if (admin != null)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"Welcome {admin.UserName}");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Welcome My First App...");
                Console.WriteLine("--------------------------------------------------");



                while (true)
                {

                Mainmenu: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Main Menu:");
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "Group Menu - 1");
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "Student Menu - 2");

                    Console.WriteLine("--------------------------------------------------");

                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Select Number for using :");
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
                        number: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Select Options:");
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
                                goto number;



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
                        number1: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "Select options:");
                            number = Console.ReadLine();
                            result = int.TryParse(number, out selectedNumber);


                            if (selectedNumber >= 0 && selectedNumber <= 6)
                            {
                                switch (selectedNumber)
                                {

                                    case (int)StudentOptions.CreateStudent:
                                        _studentController.CreateStudent();
                                        break;
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
                                goto number1;


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
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Enter correct password and username");
                goto Authentication;
            }    
        }
    }
}