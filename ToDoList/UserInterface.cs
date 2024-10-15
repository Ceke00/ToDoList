using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    using Microsoft.VisualBasic;
    using System;
    using System.ComponentModel.Design;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public class UserInterface
    {
        private TaskManager taskManager;

        public UserInterface(TaskManager taskManager)
        {
            this.taskManager = taskManager;
        }

        //Main menu choices
        public void ShowMainMenu()
        {
            while (true)
            {
                try
                {
                    Message.GenerateMenuHeader("********************  MAIN MENU  *********************", "Yellow");
                    Console.Write("You have ");
                    Message.GenerateMessage(taskManager.Tasks.Count(t => !t.IsDone).ToString(), "Red", true);
                    Console.Write(" tasks todo and ");
                    Message.GenerateMessage(taskManager.Tasks.Count(t => t.IsDone).ToString(), "Green", true);
                    Console.WriteLine(" tasks are done.");
                    Message.GenerateDivider("-", "Yellow", 54);
                    Message.GenerateMessage("Pick an option:", "Cyan");
                    Console.WriteLine("(1) Show Task List (by date or category)");
                    Console.WriteLine("(2) Add New Task");
                    Console.WriteLine("(3) Edit Task (update, mark as done/not done, remove)");
                    Console.WriteLine("(4) Save and quit");
                    Message.GenerateDivider("-", "Yellow", 54);

                    string choice = Console.ReadLine().Trim();

                    switch (choice)
                    {
                        case "1":
                            ShowTaskList();
                            break;
                        case "2":
                            AddNewTask();
                            break;
                        case "3":
                            EditTask();
                            break;
                        case "4":
                            SaveAndQuit();
                            return;
                        default:
                            Message.GenerateMessage("Invalid option. Write 1, 2, 3 or 4.", "Red");
                            break;
                    }
                }
                catch (Exception e) { Message.GenerateMessage("An error ocurred: " + e.Message, "Red"); }
            }
        }

        //Showing task list
        private void ShowTaskList()
        {
            while (true)
            {
                try
                {
                    int choice = GetIntInput("Show tasks by (1) Date or (2) Category (or 0 for Main Menu)? ", 2);
                    if (choice == 0) break;
                    Message.GenerateTableHeader("TASK TITLE".PadRight(20) + "DUE DATE".PadRight(20) + "STATUS".PadRight(20) + "CATEGORY");

                    if (choice == 1)
                    {
                        var tasks = taskManager.GetTasksByDate();
                        foreach (var task in tasks)
                        {
                            Console.WriteLine(task);
                        }
                        Message.GenerateDivider("-", "Cyan", 86);
                        break;
                    }
                    else if (choice == 2)
                    {
                        var tasks = taskManager.GetTasksByCategory();
                        foreach (var task in tasks)
                        {
                            Console.WriteLine(task);
                        }
                        Message.GenerateDivider("-", "Cyan", 86);
                        break;
                    }
                }
                catch (Exception e) { Message.GenerateMessage("An error ocurred: " + e.Message, "Red"); }
            }
        }

        //Adding new tasks
        private void AddNewTask()
        {
            Message.GenerateMenuHeader("*******************  ADD NEW TASK  *******************", "Red");
            while (true)
            {
                try
                {
                    string title = GetStringInput("Enter task title: ");
                    DateTime dueDate = GetDateInput("Enter due date (yyyy-MM-dd): ");
                    string category = GetStringInput("Enter category name: ");
                    Task newTask = new Task(title, dueDate, category);
                    taskManager.AddTask(newTask);
                    Message.GenerateMessage("Task added successfully!", "Green");
                    break;
                }
                catch (Exception e)
                {
                    Message.GenerateMessage(e.Message, "Red");
                }
            }
        }

        //Editing tasks
        private void EditTask()
        {
            Message.GenerateMenuHeader("********************  EDIT TASK  *********************", "Red");
            Message.GenerateTableHeader("NR".PadRight(11) + "TASK TITLE".PadRight(20) + "DUE DATE".PadRight(20) + "STATUS".PadRight(20) + "CATEGORY");

            //Numbered tasks
            for (int i = 0; i < taskManager.Tasks.Count; i++)
            {
                Console.WriteLine((i + 1) + ".".PadRight(10) + taskManager.Tasks[i]);
            }
            Message.GenerateDivider("-", "Cyan", 86);
            while (true)
            {
                try
                {
                    int choiceTask = GetIntInput("Enter the number of the task you want to edit (or 0 for Main Menu): ", taskManager.Tasks.Count);
                    if (choiceTask == 0) break;
                    int index = choiceTask - 1;

                    if (index >= 0 && index < taskManager.Tasks.Count)
                    {
                        Message.GenerateDivider("-", "Cyan", 54);
                        int choice = GetIntInput("What do you want to do? \n(0) Back to Main Menu\n(1) Update Task \n(2) Mark as Done \n(3) Mark as Not Done \n(4) Remove Task \nEnter option: ", 4);
                        Message.GenerateDivider("-", "Cyan", 54);
                        switch (choice)
                        {
                            //Showing current data before input
                            case 1:
                                Console.WriteLine("Current title: " + taskManager.Tasks[index].Title);
                                string newTitle = GetStringInput("Enter new title: ");
                                Console.WriteLine("Current date: " + taskManager.Tasks[index].DueDate.ToString("yyyy-MM-dd"));
                                DateTime newDueDate = GetDateInput("Enter new due date (yyyy-mm-dd): ");
                                Console.WriteLine("Current cathegory:" + taskManager.Tasks[index].Category);
                                string newCategory = GetStringInput("Enter new category: ");
                                taskManager.EditTask(index, newTitle, newDueDate, newCategory);
                                Message.GenerateMessage("Task updated successfully!", "Green");
                                break;
                            case 2:
                                taskManager.MarkTaskAsDone(index);
                                Message.GenerateMessage("Task marked as done!", "Green");
                                break;
                            case 3:
                                taskManager.MarkTaskAsNotDone(index);
                                Message.GenerateMessage("Task marked as NOT done!", "Green");
                                break;
                            case 4:
                                taskManager.RemoveTask(index);
                                Message.GenerateMessage("Task removed successfully!", "Green");
                                break;
                            case 0: break;
                            default:
                                Message.GenerateMessage("Invalid option, choose 1,2 or 3.", "Red");
                                break;
                        }
                        break;
                    }
                    else
                    {
                        Message.GenerateMessage("Invalid task number.", "Red");
                    }
                }
                catch (Exception e) { Message.GenerateMessage(e.Message, "Red"); }
            }
        }

        private void SaveAndQuit()
        {
            // Implement file saving logic here
            Console.WriteLine("Tasks saved. Exiting program.");
        }


        //Validate int input from user, return correct int
        private static int GetIntInput(string prompt, int nrOfChoices)
        {
            while (true)
            {
                try
                {
                    Message.GenerateMessage(prompt, "Yellow", true);
                    string input = Console.ReadLine().Trim();
                    if (!string.IsNullOrEmpty(input))
                    {
                        if (int.TryParse(input, out int choice))
                        {
                            if (choice >= 0 && choice <= nrOfChoices) return choice;
                            else throw new ArgumentOutOfRangeException("Not a correct choice.");
                        }
                        else
                        {
                            throw new FormatException("Only enter numbers.");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("No input registered. Try again!");
                    }
                }

                catch (Exception e)
                {
                    Message.GenerateMessage(e.Message, "Red");
                }
            }
        }

        //Validate DateTime input, return a correct date
        private static DateTime GetDateInput(string prompt)
        {
            while (true)
            {
                try
                {
                    Message.GenerateMessage(prompt, "Yellow", true);
                    string input = Console.ReadLine().Trim();
                    if (!string.IsNullOrEmpty(input))
                    {
                        if (DateTime.TryParse(input, out DateTime date))
                        {
                            if (date < DateTime.Now.Date)
                            {
                                throw new FormatException("The date you entered has already passed.");
                            }
                            else return date;
                        }
                        else
                        {
                            throw new FormatException("Not a correct date. Format yyyy-MM-dd.");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("No input registered. Try again!");
                    }
                }

                catch (Exception e)
                {
                    Message.GenerateMessage(e.Message, "Red");
                }
            }
        }

        //Validate string input, return a string
        private static string GetStringInput(string prompt)
        {
            while (true)
            {
                try
                {
                    Message.GenerateMessage(prompt, "Yellow", true);
                    string input = Console.ReadLine().Trim();
                    if (!string.IsNullOrEmpty(input))
                    {
                        return input;
                    }
                    else
                    {
                        throw new ArgumentException("No input registered. Try again!");
                    }
                }
                catch (Exception e)
                {
                    Message.GenerateMessage(e.Message, "Red");
                }
            }
        }
    }
}
