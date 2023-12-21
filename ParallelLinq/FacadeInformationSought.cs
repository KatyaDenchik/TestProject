using ParallelLinqTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole;

namespace ParallelLinqTask
{
    public class FacadeInformationSought<T> : IInformationSought
    {
        private readonly IInformationSought linq;

        public FacadeInformationSought(IInformationSought linq)
        {
            this.linq = linq;
        }

        public IEnumerable<T> GetSortCollection<T>(IEnumerable<T> collection, Func<T, bool> predicate) where T : Unit
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "log.txt");

            var sortedCollection = linq.GetSortCollection(collection, predicate);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var unit in sortedCollection)
                {
                    writer.WriteLine(unit.Name);
                }
            }

            System.Diagnostics.Process.Start("notepad.exe", filePath);


            return linq.GetSortCollection(collection, predicate);
        }
    }
}
