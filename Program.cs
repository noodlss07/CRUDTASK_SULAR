namespace CRUDTASK_SULAR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string[] finishedTasks = {"Task 1: ACTIVITY 1",
                "Task 2: ACTIVITY 2",
                "Task 3: ACTIVITY 3",
                "Task 4: ACTIVITY 4" };

            string[] UnFinishedTasks = {"Task 5: ACTIVITY 5",
                "Task 6: ACTIVITY 6",
                "Task 7: ACTIVITY 7",
                "Task 8: ACTIVITY 8" };



            Console.Write("\nPress Y to see Finished Tasks: ");
            string userInput = Console.ReadLine();

            if (userInput == "Y" || userInput == "y")
            {
                for (int i = 0; i < finishedTasks.Length; i++)
                {
                    Console.WriteLine(finishedTasks[i]);
                }
            }
            else if (userInput == "N" || userInput == "n")
            {
               Console.WriteLine("\nYou have chosen not to see the Finished Tasks.");
               Console.Write("\nPress Y to see Unfinished Tasks:");
               string userInput2 = Console.ReadLine();

               if (userInput2 == "Y" || userInput2 == "y")
                {
                    for (int i = 0; i < UnFinishedTasks.Length; i++)
                    {
                        Console.WriteLine(UnFinishedTasks[i]);
                    }
                }
                else if (userInput2 == "N" || userInput2 == "n")
                {
                    Console.WriteLine("\nYou have chosen not to see the Unfinished Tasks.");
                }

            }



        }

    }
}
