using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelLinqTask.Interfaces
{
    public interface IInformationSought
    {
        IEnumerable<T> GetSortCollection<T>(IEnumerable<T> collection, Func<T, bool> predicate);
    }
}
