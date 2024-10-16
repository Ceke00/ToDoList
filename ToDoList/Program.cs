using System.Reflection;

using ToDoList;

class Program
{
    public static void Main()
    {
        TaskManager taskManager = new TaskManager();
        Message.GenerateMenuHeader("*************  WELCOME TO THE TODO-LIST  *************", "Green");
        FileManager fileManager = new FileManager(taskManager);
        fileManager.LoadTasksFromFile("tasks.json");
        Message.GenerateDivider("*", "Green", 54);
        UserInterface ui = new UserInterface(taskManager, fileManager);
        ui.ShowMainMenu();
    }
}
