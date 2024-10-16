using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ToDoList
{
    public class FileManager
    {
        private TaskManager taskManager;

        public FileManager(TaskManager taskManager)
        {
            this.taskManager = taskManager;
        }

        //Getting saved tasks from file on load
        public void LoadTasksFromFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    //Reading JSON from file
                    string json = File.ReadAllText(filePath);
                    //JSON string converts to list of objects
                    var tasks = JsonSerializer.Deserialize<List<Task>>(json);
                    if (tasks != null)
                    {
                        taskManager.Tasks.Clear();
                        taskManager.Tasks.AddRange(tasks);
                        Message.GenerateMessage("Tasks uploaded successfully!", "Green");
                    }
                }
                else
                {
                    Message.GenerateMessage("No previous saved tasks to load.", "Red");
                }
            }
            catch (Exception e)
            {
                Message.GenerateMessage("Could not load tasks from file: " + e.Message, "Red");
            }
        }

        //Save tasks to file
        public void SaveTasksToFile(string filePath)
        {
            try
            {
                //Converting list of objects to JSON 
                string json = JsonSerializer.Serialize(taskManager.Tasks);
                //Writing JSON to file
                File.WriteAllText(filePath, json);
                Message.GenerateMessage("Tasks saved successfully", "Green");
            }
            catch (Exception e) { Message.GenerateMessage("Could not save tasks to file: " + e.Message, "Red"); }
        }
    }
}
