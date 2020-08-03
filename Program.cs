using System;
using System.Collections.Generic;
using System.Globalization;

namespace TaskListLab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> menu = new List<string>() { "List Task", "Add Task", "Delete Task", "Mark Complete", "Edit Task", "Team Member Task List", "Quit Program" };
            List<Tasking> tasks = new List<Tasking>();
            Tasking newTask = new Tasking("Robbie Kress", "Better time management", "08/02/2020");
            Tasking newTask1 = new Tasking("Papa John", "Add tipping system to PapaJohns.com", "08/20/202");
            Tasking newTask2 = new Tasking("Papa Junior", "Is going to be in the house", "09/28/2020");
            Tasking newTask3 = new Tasking("Little Ceasers", "Change name to Little Seizures", "11/11/1111");
            tasks.Add(newTask);
            tasks.Add(newTask1);
            tasks.Add(newTask2);
            tasks.Add(newTask3);
            while (true)
            {
                Console.WriteLine("Main Menu");
                Tasking.ListMenu(menu);
                string choice = Tasking.UserChoice();
                if (choice == "1")
                {
                    Console.WriteLine();
                    Tasking.ListTasks(tasks);
                }
                if (choice == "2")
                {
                    Console.WriteLine();
                    Tasking.AddTask(tasks);
                }
                if (choice == "3")
                {
                    Console.WriteLine();
                    Tasking.DeleteTask(tasks);
                }
                if (choice == "4")
                {
                    Console.WriteLine();
                    Tasking.MarkComplete(tasks);
                }
                if (choice == "5")
                {
                    Console.WriteLine();
                    Tasking.EditTask(tasks);
                }
                if (choice == "6")
                {
                    Console.WriteLine();
                    Tasking.PrintUserTasks(tasks);
                }
                if (choice == "7")
                {
                    Console.WriteLine();
                    Console.WriteLine("Buh bye");
                    break;
                }
            }
        }
    }
}