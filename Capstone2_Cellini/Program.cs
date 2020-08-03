using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Capstone2_Cellini
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> TaskList = new List<Task>() { };
            while (true)
            {
                try
                {
                    Console.WriteLine("\nWelcome to the task manager");
                    Console.WriteLine($"Currently you have " + " tasks.");
                    Console.WriteLine("1. List tasks");
                    Console.WriteLine("2. Add tasks");
                    Console.WriteLine("3. Delete tasks");
                    Console.WriteLine("4. Mark tasks as complete");
                    Console.WriteLine("5. Quit");

                    Console.WriteLine($"\nCurrently, you have {TaskList.Count} tasks in your list.");
                    Console.WriteLine("What would you like to do? (Select a number between 1 and 5:) ");
                    string input = Console.ReadLine();
                    int selection = int.Parse(input);

                    if (1 <= selection && selection <= 5)
                    {
                        if (selection == 1)
                        {
                            PrintTasks(TaskList);
                        }
                        else if (selection == 2)
                        {
                            AddTask(TaskList);
                        }
                        else if (selection == 3)
                        {
                            DeleteTask(TaskList);
                        }
                        else if (selection == 4)
                        {
                            MarkComplete(TaskList);
                        }
                        else if (selection == 5)
                        {
                            Console.WriteLine("\nThank you for using the task manager");
                            Console.WriteLine("Press any key to exit");
                            Console.ReadKey();
                            break;

                        }
                        else
                        {
                            Console.WriteLine("\nNumber was not in between 1 and 5. Please try again");
                            Console.Clear();
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nThe input provided was not a number. Please try again.");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("\nError. Please try again.");
                }
            }

        }
        public static void PrintTasks(List<Task> TaskList)
        {
            //Couldn't get it to loop like I wanted to but I'd like to keep the code. Disregard.

            //bool repeat = true;
            //while (repeat == true)
            //{
            //    Console.WriteLine("Would you like to see the tasks of only one team member? (Y/N): ");
            //    string coninput = Console.ReadLine().ToLower();

            //    if (coninput == "n" || coninput == "no")
            //    {
            //        break;
            //    }
            //    else if (coninput == "y" || coninput == "yes")
            //    {
            //        bool repeat2 = true;
            //        while (repeat2 == true)
            //        {
            //            Console.WriteLine("Please enter the name of that member: ");
            //            string input = Console.ReadLine();
            //            foreach (Task task in TaskList)
            //            {
            //                if (task.TMName == input)
            //                {
            //                    Console.WriteLine($"\n#{task.TaskNumber}: \n{task.TMName}");
            //                    Console.WriteLine($"Description: {task.TaskDesc}");
            //                    Console.WriteLine($"Due: {task.DueDate}");
            //                    string completion;
            //                    if (task.TaskComplete == true)
            //                    {
            //                        completion = "Yes";
            //                    }
            //                    else
            //                    {
            //                        completion = "No";
            //                    }

            //                    Console.WriteLine("Completed?: " + completion);
            //                }
            //                else if (task.TMName != input)
            //                {
            //                    Console.WriteLine("Please enter a valid name.");
            //                    continue;
            //                }
            //            }
            //            break;
            //        }
            //        break;
            //    }
            //    else if (coninput != "y" || coninput != "yes" || coninput != "n" || coninput != "no")
            //    {
            //        Console.WriteLine("Invalid input. Please try again.");
            //        continue;
            //    }


            foreach (Task task in TaskList)
            {
                Console.WriteLine($"\n#{task.TaskNumber}: \n{task.TMName}");
                Console.WriteLine($"Description: {task.TaskDesc}");
                Console.WriteLine($"Due: {task.DueDate}");
                string completion;
                if (task.TaskComplete == true)
                {
                    completion = "Yes";
                }
                else
                {
                    completion = "No";
                }

                Console.WriteLine("Completed?: " + completion);
                break;
            }
        }

        public static void AddTask(List<Task> TaskList)
        {
            Console.WriteLine("\nWho has been assigned the task?: ");
            string name = Console.ReadLine();

            Console.WriteLine("Please describe the task: ");
            string desc = Console.ReadLine();

            Console.WriteLine("When is the task due?: ");
            string due = Console.ReadLine();

            Task addedTask = new Task(0, name, desc, due, false);

            TaskList.Add(addedTask);
            for (int i = 0; i < TaskList.Count; i++)
            {
                TaskList[i].TaskNumber = i + 1;
            }

            Console.WriteLine("\nSuccessfully added task to list.");
        }

        public static void DeleteTask(List<Task> TaskList)
        {
            bool repeat = true;
            while (repeat == true)
            {
                foreach (Task task in TaskList)
                {
                    Console.WriteLine($"\n#{task.TaskNumber}: \n{task.TMName}");
                }
                try
                {
                    Console.WriteLine("Which task would you like to delete? (Please enter the number of the task)");
                    Console.WriteLine("If you do not wish to delete any tasks, type 'back': ");

                    string input = Console.ReadLine();
                    if (input == "back")
                    {
                        break;
                    }

                    int numinput = int.Parse(input) - 1;

                    //Using this variable solely for the write line. Don"t know if adding the number
                    //back will change the task being deleted. Not taking any chances.
                    int numinput2 = int.Parse(input) - 1;

                    Console.WriteLine("Are you sure you want to delete " + (numinput2 + 1) + "? (Y/N): ");
                    string coninput = Console.ReadLine().ToLower();

                    bool repeat2 = true;
                    while (repeat2 == true)
                    {
                        if (coninput == "n" || coninput == "no")
                        {
                            break;
                        }
                        else if (coninput == "y" || coninput == "yes")
                        {
                            TaskList.RemoveAt(numinput);
                            Console.WriteLine("Successfully deleted task from list.");
                            break;
                        }
                        else if (coninput != "y" || coninput != "yes" || coninput != "n" || coninput != "no")
                        {
                            Console.WriteLine("Invalid input. Please try again.");
                            continue;
                        }
                        break;
                    }

                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("No task of that number currently exists. Please try again.");
                    if (TaskList.Count == 0)
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("The input provided was not a number. Please try again.");
                    if (TaskList.Count == 0)
                    {
                        break;
                    }
                }
            }
        }

        public static void MarkComplete(List<Task> TaskList)
        {
            foreach (Task task in TaskList)
            {
                Console.WriteLine($"\n#{task.TaskNumber}: \n{task.TMName}");
            }
            bool repeat = true;
            while (repeat == true)
            {
                try
                {
                    Console.WriteLine("\nPlease input the number of the task that you would like to mark complete. ");
                    Console.WriteLine("If you do not wish to mark anything completed, type 'back': ");
                    string input = Console.ReadLine();
                    if (input == "back")
                    {
                        break;
                    }

                    int numinput = int.Parse(input);

                    if (numinput > TaskList.Count)
                    {
                        Console.WriteLine("\nNo task of that number currently exists. Please try again.");
                        if (TaskList.Count == 0)
                        {
                            break;
                        }
                    }
                    else
                    {
                        foreach (Task task in TaskList)
                        {
                            if (task.TaskNumber == numinput)
                            {
                                task.TaskComplete = true;
                                Console.WriteLine("\nSuccessfully marked task to complete.");
                                repeat = false;
                            }
                        }
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("No task of that number currently exists. Please try again.");
                    if (TaskList.Count == 0)
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("The input provided was not a number. Please try again.");
                    if (TaskList.Count == 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}
