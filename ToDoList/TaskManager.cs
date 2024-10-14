using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TaskManager
    {
        public List<Task> Tasks { get; set; }

        public TaskManager()
        {
            Tasks = new List<Task>();
        }

        //Adding new task
        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }

        //Editing task properties
        public void EditTask(int index, string newTitle, DateTime newDueDate, string newCategory)
        {
            Tasks[index].Title = newTitle;
            Tasks[index].DueDate = newDueDate;
            Tasks[index].Category = newCategory;
        }

        //Removes tasks
        public void RemoveTask(int index)
        {
            Tasks.RemoveAt(index);
        }

        //Changing status of task
        public void MarkTaskAsDone(int index)
        {
            Tasks[index].IsDone = true;
        }

        //Changing status of task
        public void MarkTaskAsNotDone(int index)
        {
            Tasks[index].IsDone = false;
        }

        //Ordering tasks by date
        public List<Task> GetTasksByDate()
        {
            return Tasks.OrderBy(t => t.DueDate).ToList();
        }

        //Ordering by category name
        public List<Task> GetTasksByCategory()
        {
            return Tasks.OrderBy(t => t.Category).ToList();
        }
    }
}
