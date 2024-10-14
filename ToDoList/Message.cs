using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Message
    {
        //Generating colorized messages 
        public static void GenerateMessage(string message, string color, bool sameLine = false)
        {
            switch (color)
            {
                case "Red": Console.ForegroundColor = ConsoleColor.Red; break;
                case "Green": Console.ForegroundColor = ConsoleColor.Green; break;
                case "Yellow": Console.ForegroundColor = ConsoleColor.Yellow; break;
                case "Cyan": Console.ForegroundColor = ConsoleColor.Cyan; break;
                case "Blue": Console.ForegroundColor = ConsoleColor.Blue; break;
            }
            if (sameLine) Console.Write(message);
            else Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
