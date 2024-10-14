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

        public Task(string title, DateTime dueDate, string category)
        {
            Title = title;
            DueDate = dueDate;
            IsDone = false;
            Category = category;
        }

        public override string ToString()
        {
            if (IsDone)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else
            {
                Console.ResetColor();
            }
            return Title.PadRight(20) + DueDate.ToString("yyyy-MM-dd").PadRight(20) + (IsDone ? "Done" : "Not Done").PadRight(20) + Category;
        }
    }
}
