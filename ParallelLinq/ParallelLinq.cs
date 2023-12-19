using ParallelLinqTask.Interfaces;
using System.Diagnostics;

namespace ParallelLinqTask
{
    public class ParallelLinq : IInformationSought
    {
        public IEnumerable<T> GetSortCollection<T>(IEnumerable<T> collection, Func<T, bool> predicate)
        {
            var rez = collection.AsParallel().Where(predicate);

            return rez;
        }
    }
}
