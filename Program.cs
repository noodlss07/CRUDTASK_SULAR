using System;
using TaskBusinessLayer;
using System.Collections.Generic;
using TaskMODEL;

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
                    Console.Write("Task Name: ");
                    string nameInput = Console.ReadLine();
                    Console.WriteLine(appService.CreateTask(nameInput));
                    Console.WriteLine("Saving..."); System.Threading.Thread.Sleep(1500);
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Loading...\n"); System.Threading.Thread.Sleep(1500);
                    Console.WriteLine("\n====================================");
                    Console.WriteLine("          PREVIEW OF TASK/s");
                    Console.WriteLine("====================================");
                    List<TaskModels> tasks = appService.GetAllTasks();
                    for (int i = 0; i < tasks.Count; i++) Console.WriteLine((i + 1) + ". " + tasks[i].taskName);
                    if (tasks.Count == 0) Console.WriteLine("The list is empty.");
                }
                else if (choice == "3")
                {
                    Console.WriteLine("\n====================================");
                    Console.WriteLine("         MODIFYING OF TASK/s");
                    Console.WriteLine("====================================");
                    Console.Write("Number to update: ");
                    int num = int.Parse(Console.ReadLine());
                    Console.WriteLine("Loading...\n"); System.Threading.Thread.Sleep(1500);
                    Console.Write("New Name: ");
                    string newName = Console.ReadLine();
                    Console.WriteLine(appService.UpdateTaskLogic(num, newName));
                    Console.WriteLine("Saving..."); System.Threading.Thread.Sleep(1500);
                }
                else if (choice == "4")
                {
                    Console.WriteLine("\n====================================");
                    Console.WriteLine("          DELETION OF TASK/s");
                    Console.WriteLine("====================================");
                    appService.ClearAll();
                    Console.WriteLine("Cleared. Saving..."); System.Threading.Thread.Sleep(1500);
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
