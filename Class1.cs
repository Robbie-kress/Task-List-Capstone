using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TaskListLab
{
    class Tasking
    {
        #region
        private string teamMemberName;
        private string taskDescription;
        private string dueDate;
        private bool complete;
        #endregion
        #region Properties
        public string TeamMemberName
        {
            get
            {
                return teamMemberName;
            }
            set
            {
                teamMemberName = value;
            }
        }
        public string TaskDescription
        {
            get
            {
                return taskDescription;
            }
            set
            {
                taskDescription = value;
            }
        }
        public string DueDate
        {
            get
            {
                return dueDate;
            }
            set
            {
                dueDate = value;
            }
        }
        public bool Complete
        {
            get
            {
                return complete;
            }
            set
            {
                complete = value;
            }
        }
        #endregion

        #region Constructors
        public Tasking()
        {

        }
        public Tasking(string _teamMemberDescription, string _taskDescription, string _dueDate, bool _complete)
        {
            teamMemberName = _teamMemberDescription;
            taskDescription = _taskDescription;
            dueDate = _dueDate;
            complete = _complete;
        }
        public Tasking(string _teamMemberName, string _taskDescription, string _dueDate)
        {
            teamMemberName = _teamMemberName;
            taskDescription = _taskDescription;
            dueDate = _dueDate;
        }
        #endregion


        #region Methods
        public static void ListMenu(List<string> mainMenu)
        {
            int i = 1;
            foreach (string item in mainMenu)
            {
                Console.WriteLine($"{i}. {item}");
                i++;
            }
        }

        public static string UserChoice()
        {
            string input;
            while (true)
            {
                Console.Write("Please pick a number to continue. ");
                input = Console.ReadLine().Trim();
                if (input == "1")
                {
                    break;
                }
                if (input == "2")
                {
                    break;
                }
                if (input == "3")
                {
                    break;
                }
                if (input == "4")
                {
                    break;
                }
                if (input == "5")
                {
                    break;
                }
                if (input == "6")
                {
                    break;
                }
                if (input == "7")
                {
                    break;
                }
                Console.WriteLine("Please enter a number from 1-7");
            }
            return input;
        }

        public static List<Tasking> AddTask(List<Tasking> tasks)
        {
            DateTime due;
            Console.WriteLine("Add a new task");
            Console.Write("Team member's name: ");
            string name = Console.ReadLine();
            Console.Write("Task description: ");
            string description = Console.ReadLine();
            Console.Write("When will it needed to be completed by?: ");
            while (!DateTime.TryParse(Console.ReadLine(), out due))
            {
                Console.WriteLine("Enter a valid date mm/dd/yy");
                Console.Write("When is it due: ");
            }
            string due1 = due.ToShortDateString();
            Tasking newItems = new Tasking(name, description, due1);
            tasks.Add(newItems);
            Console.WriteLine("Task Entered!");
            Console.WriteLine();
            return tasks;
        }

        public static void ListTasks(List<Tasking> tasks)
        {
            int i = 1;
            foreach (Tasking task in tasks)
            {
                Console.WriteLine($"{i}. {task.TeamMemberName,-25}|Due on {task.DueDate,-10} |Completion status: {task.Complete} | Description = {task.TaskDescription}.");
                i++;
            }
            Console.WriteLine();
        }


        public static List<Tasking> DeleteTask(List<Tasking> tasks)
        {
            Tasking.ListTasks(tasks);
            Console.Write("Which task would you like to delete? ");
            int choice = 0;
            string answer; //honestly thought this was spelt wrong just remembering your comment.
            while (true)
            {
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    if (choice <= 0 || choice > tasks.Count)
                    {
                        throw new Exception("Enter a number in range ");
                    }
                }
                catch (FormatException)
                {
                    Console.Write("That is not a number! Enter a number in range: ");
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
                if (choice <= tasks.Count && choice > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{choice}. {tasks[choice - 1].TeamMemberName,-25}|Due on {tasks[choice - 1].DueDate,-10} |Completion status: {tasks[choice - 1].Complete} | Description = {tasks[choice - 1].TaskDescription}.");
                    Console.WriteLine();
                    while (true)
                    {
                        Console.Write("Are you sure you wish to delete? y/n ");
                        answer = Console.ReadLine();
                        if (answer == "y")
                        {
                            tasks.RemoveAt(choice - 1);
                            Console.WriteLine($"Task {choice} deleted!");
                            Console.WriteLine();
                            break;
                        }
                        if (answer == "n")
                        {
                            Console.WriteLine($"Task {choice} not changed");
                            Console.WriteLine();
                            break;
                        }
                        Console.WriteLine("Enter y or n!");
                    }
                    break;
                }
            }
            return tasks;
        }

        public static List<Tasking> MarkComplete(List<Tasking> tasks)
        {
            Tasking.ListTasks(tasks);
            Console.Write("Which task do you want to mark complete? ");
            int choice = 0;
            string answer;
            while (true)
            {
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    if (choice <= 0 || choice > tasks.Count)
                    {
                        throw new Exception("Enter a number in range ");
                    }
                }
                catch (FormatException)
                {
                    Console.Write("That is not a number! Enter a number in range: ");
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
                if (choice <= tasks.Count && choice > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{choice}. {tasks[choice - 1].TeamMemberName,-25}|Due on {tasks[choice - 1].DueDate,-10} |Completion status: {tasks[choice - 1].Complete} | Description = {tasks[choice - 1].TaskDescription}.");
                    Console.WriteLine();
                    while (true)
                    {
                        Console.Write("Are you sure you wish to mark complete? y/n ");
                        answer = Console.ReadLine();
                        if (answer == "y")
                        {
                            tasks[choice - 1].Complete = true;
                            Console.WriteLine($"Task {choice} completed!");
                            Console.WriteLine();
                            break;
                        }
                        if (answer == "n")
                        {
                            Console.WriteLine($"Task {choice} not changed");
                            Console.WriteLine();
                            break;
                        }
                        Console.WriteLine("Enter y or n!");
                    }
                    break;
                }
            }
            return tasks;
        }

        public static List<Tasking> EditTask(List<Tasking> tasks)
        {
            Tasking.ListTasks(tasks);
            Console.Write("Which task do you want to edit? ");
            int choice = 0;
            string answer;
            bool var;
            while (true)
            {
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    if (choice <= 0 || choice > tasks.Count)
                    {
                        throw new Exception("Enter a number in range ");
                    }
                }
                catch (FormatException)
                {
                    Console.Write("That is not a number! Enter a number in range: ");
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
                if (choice <= tasks.Count && choice > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{choice}. {tasks[choice - 1].TeamMemberName,-25}|Due on {tasks[choice - 1].DueDate,-10} |Completion status: {tasks[choice - 1].Complete} | Description = {tasks[choice - 1].TaskDescription}.");
                    Console.WriteLine();
                    while (true)
                    {
                        Console.Write("Are you sure you wish to edit? y/n ");
                        answer = Console.ReadLine();
                        if (answer == "y")
                        {
                            DateTime due;
                            Console.WriteLine("EDIT TASK");
                            Console.Write("Team member name: ");
                            string name = Console.ReadLine();
                            Console.Write("Task description: ");
                            string description = Console.ReadLine();
                            Console.Write("When is it due: ");
                            while (!DateTime.TryParse(Console.ReadLine(), out due))
                            {
                                Console.WriteLine("Enter a valid date mm/dd/yy");
                                Console.Write("When is it due: ");
                            }
                            string due1 = due.ToShortDateString();
                            Console.Write("Is it complete? true or false: ");
                            while (!bool.TryParse(Console.ReadLine(), out var))
                            {
                                Console.WriteLine("Enter true or false ");
                                Console.Write("Is it complete? ");
                            }
                            tasks[choice - 1].TeamMemberName = name;
                            tasks[choice - 1].DueDate = due1;
                            tasks[choice - 1].TaskDescription = description;
                            tasks[choice - 1].Complete = var;
                            Console.WriteLine($"Task {choice} edited!");
                            Console.WriteLine();
                            break;
                        }
                        if (answer == "n")
                        {
                            Console.WriteLine($"Task {choice} not changed");
                            Console.WriteLine();
                            break;
                        }
                        Console.WriteLine("Enter y or n! ");
                    }
                    break;
                }
            }
            return tasks;
        }

        public static void PrintUserTasks(List<Tasking> tasks)
        {
            Console.Write("Which team member's tasks would you like to see? Please enter full name ");
            string answer = Console.ReadLine().ToLower();
            int i = 1;
            try
            {

                foreach (Tasking task in tasks)
                {
                    if (answer == task.TeamMemberName.ToLower())
                    {
                        Console.WriteLine($"{i}. {task.TeamMemberName,-25}|Due on {task.DueDate,-10} |Completion status: {task.Complete} | Description = {task.TaskDescription}.");
                        i++;
                    }
                }
                if (i == 1)
                {
                    throw new Exception("User not found");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
        }
        #endregion

    }
}