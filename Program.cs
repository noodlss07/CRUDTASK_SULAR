using System.ComponentModel;

namespace CRUDTASK_SULAR
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] list = {
            "Create Tasks",
            "Review Tasks",
            "Update Tasks",
            "Delete Tasks",
            "Exit"
        };
            string[] tasks = new string[5];
            int taskCount = 0;

            Console.WriteLine("====================================");
            Console.WriteLine("\t\tMENU");
            Console.WriteLine("====================================");

            for (int x = 0; x < list.Length; x++)
            {
                Console.WriteLine("\t" + (x + 1) + ". " + list[x]);
            }
            Console.WriteLine("====================================");

            while (true)
            {
                Console.Write("\nWhat would you like to do?: ");
                string choice = Console.ReadLine().ToLower().Trim();
                

                if (choice == "1" || choice == "create" || choice == "create tasks")
                {
                    if (taskCount < 5)
                    {
                        Console.Write("Enter task name: ");
                        tasks[taskCount] = Console.ReadLine();
                        taskCount++;
                        Console.WriteLine("Task added!");
                        Console.WriteLine("\n====================================");
                    }
                    else
                    {
                        Console.WriteLine("List is full!");
                        Console.WriteLine("\n====================================");
                    }
                }


                else if (choice == "2" || choice == "review" || choice == "review tasks")
                {
                    Console.WriteLine("\n--- YOUR CURRENT TASKS ---");
                    if (taskCount == 0)
                    {
                        Console.WriteLine("[Empty]");
                        Console.WriteLine("\n====================================");
                    }
                    else
                    {
                        for (int i = 0; i < taskCount; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + tasks[i]);
                        }
                        Console.WriteLine("\n====================================");
                    }
                }


                else if (choice == "3" || choice == "update" || choice == "update tasks")
                {
                    if (taskCount == 0)
                    {
                        Console.WriteLine("Nothing to update.");
                        Console.WriteLine("\n====================================");
                    }
                    else
                    {
                        Console.Write("Enter the task number to update (1-" + taskCount + "): ");
                        int index = int.Parse(Console.ReadLine()) - 1;

                        if (index >= 0 && index < taskCount)
                        {
                            Console.Write("Enter new task name: ");
                            tasks[index] = Console.ReadLine();
                            Console.WriteLine("Task updated!");
                            Console.WriteLine("\n====================================");
                        }
                        else
                        {
                            Console.WriteLine("Invalid number.");
                            Console.WriteLine("\n====================================");
                        }
                    }
                }


                else if (choice == "4" || choice == "delete" || choice == "delete tasks")
                {
                    Console.Write("Are you sure you want to delete ALL tasks? (yes/no): ");
                    string confirm = Console.ReadLine().ToLower();

                    if (confirm == "yes")
                    {
                        tasks = new string[5];
                        taskCount = 0;
                        Console.WriteLine("All tasks deleted.");
                        Console.WriteLine("\n====================================");
                    }
                }


                else if (choice == "exit" || choice == "5")
                {
                    Console.WriteLine("Goodbye!");
                    Console.WriteLine("\n====================================");
                    break;

                }
            }
        }
    }
}

