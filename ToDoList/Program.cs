using System.Reflection;

// Todo list application.
//The application will allow a user to:
// - Create new tasks
// - Assign them a title and due date,
// - Choose a project for that task to belong to.
// They will need to use a text based user interface via the command-line.
// Once they are using the application, the user should be able to also:
// - Edit
// - Mark as done
// - Remove tasks.
// - Quit and save the current task list to file
// - Restart the application with the former state restored.
// The interface should look similar to the mockup below: 
// Welcome to ToDoLy
// You have X tasks todo and Y tasks are done.
// Pick an option
// (1) Show Task List (by date or project)
// (2) Add New Task
// (3) Edit Task (update, mark as done, remove)
// (4) Save and quit
// Requirements:
// The solution must achieve the following requirements:  
//  Model a task with a task title, due date, status and project  
//  Display a collection of tasks that can be sorted both by date and project  
//  Support the ability to add, edit, mark as done, and remove tasks  
//  Support a text-based user interface
//  Load and save task list to file
// The solution may also include other creative features at 
// your discretion in case you wish to show some flair. 

using ToDoList;


class Program
{
    static void Main()
    {
        TaskManager taskManager = new TaskManager();
        Message.GenerateMessage("********************************", "Green");
        Message.GenerateMessage("**  WELCOME TO THE TODO-LIST  **", "Green");
        Message.GenerateMessage("********************************", "Green");
        UserInterface ui = new UserInterface(taskManager);
        ui.ShowMainMenu();
    }
}
