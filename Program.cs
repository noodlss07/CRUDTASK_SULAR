using System;
using System.Collections.Generic;
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
                Console.WriteLine("\n---MENU ---");
                Console.WriteLine("1. Create Task");
                Console.WriteLine("2. Review Tasks");
                Console.WriteLine("3. Update Task");
                Console.WriteLine("4. Delete All");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Task Name: ");
                    string name = Console.ReadLine();
                    string result = appService.CreateTask(name);
                    Console.WriteLine(result);
                }
                else if (choice == "2")
                {
                    List<TaskModels> tasks = appService.data.GetAllTasks();
                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("The list is empty.");
                    }
                    for (int i = 0; i < tasks.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + tasks[i].Name);
                    }
                }
                else if (choice == "3")
                {
                    Console.Write("Enter number to update: ");
                    int num = int.Parse(Console.ReadLine());
                    Console.Write("New Name: ");
                    string newName = Console.ReadLine();

                    string result = appService.UpdateTaskLogic(num, newName);
                    Console.WriteLine(result);
                }
                else if (choice == "4")
                {
                    appService.data.DeleteAll();
                    Console.WriteLine("All tasks cleared.");
                }
                else if (choice == "5")
                {
                    break;
                }
            }
        }
    }
}
