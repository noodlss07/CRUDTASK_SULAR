using System;
using System.Collections.Generic;
using TaskBusinessLayer;
using TaskMODEL;

namespace CRUDTASK_SULAR
{
    internal class Program
    {
        public static void Main(string[] args)
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

                for (int x = 0; x < list.Length; x++)
                {
                    Console.WriteLine("\t" + (x + 1) + ". " + list[x]);
                }

                Console.WriteLine("====================================\n");
                Console.Write("Choose from the menu: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Task Name: ");
                    string name = Console.ReadLine();
                    string result = appService.CreateTask(name);
                    Console.WriteLine(result);

                    Console.WriteLine("Saving...");
                    System.Threading.Thread.Sleep(1500);
                }
                else if (choice == "2")
                {   
                    List<TaskModels> tasks = appService.data.ReviewTasks();
                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("The list is empty.");
                    }
                    for (int i = 0; i < tasks.Count; i++)
                    {
                        Console.WriteLine("Loading...\n");
                        System.Threading.Thread.Sleep(1500);
                        Console.WriteLine((i + 1) + ". " + tasks[i].taskName);
                    }

                }
                else if (choice == "3")
                {
                    Console.Write("Enter number to update: ");
                    int num = int.Parse(Console.ReadLine());
                    Console.WriteLine("Loading...\n");
                    System.Threading.Thread.Sleep(1500);
                    Console.Write("New Name: ");
                    string newName = Console.ReadLine();

                    string result = appService.UpdateTaskLogic(num, newName);
                    Console.WriteLine(result);
                    Console.WriteLine("Saving...");
                    System.Threading.Thread.Sleep(1500);
                }
                else if (choice == "4")
                {
                    appService.data.DeleteAll();
                    Console.WriteLine("Loading...\n");
                    System.Threading.Thread.Sleep(2500);
                    Console.WriteLine("All tasks cleared.");
                }
                else if (choice == "5")
                {
                    Console.WriteLine("Exiting...");
                    System.Threading.Thread.Sleep(700);
                    break;
                }
                
            }
        }
    }
}
