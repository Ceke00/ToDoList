using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Task
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDone { get; set; }
        public string Category { get; set; }
        public Priority Priority { get; set; }

        public Task(string title, DateTime dueDate, string category, Priority priority)
        {
            Title = title;
            DueDate = dueDate;
            IsDone = false;
            Category = category;
            Priority = priority;
        }

        public override string ToString()
        {
            if (IsDone)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            //Marks yellow if duedate is passed or today or if priority is set to high or urgent
            else if ((!IsDone && DueDate <= DateTime.Now) || (!IsDone && (Priority == Priority.High || Priority == Priority.Urgent)))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ResetColor();
            }
            return Title.PadRight(20) + DueDate.ToString("yyyy-MM-dd").PadRight(20) + (IsDone ? "Done" : "Not Done").PadRight(20) + Category.PadRight(20) + Priority;
        }
    }
}
