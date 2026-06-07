using TaskBusinessLayer;
using TaskMODEL;
using System;
using System.Collections.Generic;
namespace CRUDTASK_SULAR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskAppService appService = new TaskAppService();
            while (true)
            {
                string[] list = { 
                    "Create Tasks", 
                    "Review Tasks", 
                    "Update Tasks", 
                    "Delete Tasks",
                    "Exit" 
                };
                Console.WriteLine("\n====================================");
                Console.WriteLine("\t\tMENU");
                Console.WriteLine("====================================");

                for (int x = 0; x < list.Length; x++) Console.WriteLine("\t" + (x + 1) + ". " + list[x]);
                Console.WriteLine("====================================\n");

                Console.Write("Choose from the menu: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("\n====================================");
                    Console.WriteLine("          CREATING TASK/s");
                    Console.WriteLine("====================================");
                    Console.Write("\nTask Name: ");
                    string nameInput = Console.ReadLine();
                    Console.WriteLine(appService.CreateTask(nameInput));
                    Console.WriteLine("\nSaving..."); System.Threading.Thread.Sleep(1500);
                }
                else if (choice == "2")
                {
                    Console.WriteLine("\nLoading...\n"); System.Threading.Thread.Sleep(1500);
                    Console.WriteLine("\n====================================");
                    Console.WriteLine("          PREVIEW OF TASK/s");
                    Console.WriteLine("====================================");
                    List<TaskModels> tasks = appService.GetAllTasks();
                    for (int i = 0; i < tasks.Count; i++) Console.WriteLine("\n" + (i + 1) + ". " + tasks[i].taskName);
                    if (tasks.Count == 0) Console.WriteLine("\nThe list is empty.");
                }
                else if (choice == "3")
                {
                    Console.WriteLine("\n====================================");
                    Console.WriteLine("         MODIFYING OF TASK/s");
                    Console.WriteLine("====================================");
                    Console.Write("\nNumber to update: ");
                    int num = int.Parse(Console.ReadLine());
                    Console.WriteLine("\nLoading..."); System.Threading.Thread.Sleep(1500);
                    Console.Write("\nNew Name: ");
                    string newName = Console.ReadLine();
                    Console.WriteLine(appService.UpdateTaskLogic(num, newName));
                    Console.WriteLine("\nSaving..."); System.Threading.Thread.Sleep(1500);
                }
                else if (choice == "4")
                {
                    Console.WriteLine("\n====================================");
                    Console.WriteLine("          DELETION OF TASK/s");
                    Console.WriteLine("====================================");
                    Console.WriteLine("\n1. Delete Specific Task");
                    Console.WriteLine("2. Delete All Tasks");
                    Console.Write("\nChoose: ");
                    string delChoice = Console.ReadLine();

                    if (delChoice == "1")
                    {
                        if (appService.GetAllTasks().Count == 0)
                        {
                            Console.WriteLine("\nThe list is empty.");
                        }
                        else
                        {
                            for (int i = 0; i < appService.GetAllTasks().Count; i++)
                            {
                                Console.WriteLine("\n" + (i + 1) + ". " + appService.GetAllTasks()[i].taskName);
                            }
                            Console.Write("\nNumber to delete: ");
                            int delNum = int.Parse(Console.ReadLine());
                            int delIndex = delNum - 1;
                            if (delIndex < 0 || delIndex >= appService.GetAllTasks().Count)
                            {
                                Console.WriteLine("\nInvalid number.");
                            }
                            else
                            {
                                Console.WriteLine(appService.DeleteTaskById(appService.GetAllTasks()[delIndex].TaskId));
                            }
                            Console.WriteLine("\nSaving...");
                            System.Threading.Thread.Sleep(1500);
                        }
                    }
                    else if (delChoice == "2")
                    {
                        if (appService.GetAllTasks().Count == 0)
                        {
                            Console.WriteLine("\nThe list is empty.");
                        }
                        else
                        {
                            appService.ClearAll();
                            Console.WriteLine("\nCleared. Saving...");
                            System.Threading.Thread.Sleep(1500);
                        }
                    }
                }
                else if (choice == "5")
                {
                    Console.WriteLine("\n====================================");
                    Console.WriteLine("              GOODBYE!");
                    Console.WriteLine("====================================\n");
                    System.Threading.Thread.Sleep(700);
                    break;
                }
            }
        }
    }
}
