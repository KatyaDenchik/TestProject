using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole;

namespace ParallelLinqTask
{
    public class LoggingToTxt
    {
        public void LogToTxt<T>(IEnumerable<T> collection) where T : Unit
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "log.txt");

            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (var unit in collection)
                {
                    writer.WriteLine(unit.Name);
                }
            }

            System.Diagnostics.Process.Start("notepad.exe", filePath);
        }
    }
}
