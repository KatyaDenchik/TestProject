using ParallelLinqTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole;

namespace ParallelLinqTask
{
    public class SimpleLinq : IInformationSought
    {
        public IEnumerable<T> GetSortCollection<T>(IEnumerable<T> collection, Func<T, bool> predicate)
        {
            var rez = collection.Where(predicate);

            return rez;
        }
    }
}
