using CRUD_TASKBL;
using CRUD_TASKMODELS;
namespace CRUDTASK
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskAppService appService = new TaskAppService();

            while (true)
            {

                string[] menu = {
                    "Create Tasks",
                    "Review Tasks",
                    "Update Tasks",
                    "Delete Tasks",
                    "Exit"
            };
                string[] tasks = new string[5];
                int taskCount = 0;

                Console.WriteLine("\n====================================");
                Console.WriteLine("\t\tMENU");
                Console.WriteLine("====================================");

                for (int x = 0; x < menu.Length; x++)
                {
                    Console.WriteLine("\t" + (x + 1) + ". " + menu[x]);
                }
                Console.WriteLine("====================================\n");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter task name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine(appService.CreateTask(name));
                }
                else if (choice == "2")
                {
                    int count = appService.GetCount();
                    if (count == 0) Console.WriteLine("\n[Empty]");
                    else
                    {
                        TaskModel[] list = appService.GetTasks();
                        for (int i = 0; i < count; i++)
                            Console.WriteLine((i + 1) + ". " + list[i].Name);
                    }
                }
                else if (choice == "3")
                {
                    Console.Write("Enter task number to update: ");
                    if (int.TryParse(Console.ReadLine(), out int num))
                    {
                        Console.Write("Enter new name: ");
                        string newName = Console.ReadLine();
                        Console.WriteLine(appService.UpdateTaskLogic(num, newName));
                    }
                    else { Console.WriteLine("\nInvalid input. Use numbers."); }
                }
                else if (choice == "4")
                {
                    appService.Clear();
                    Console.WriteLine("\nAll tasks deleted.");
                }
                else if (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5")
                {
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                }
                else if (choice == "5")
                {
                    Console.WriteLine("\nGoodbye!");
                    Console.WriteLine("\n====================================");
                    break;
                } 
            }
            
        }
    }
}
