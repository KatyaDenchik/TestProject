using ParallelLinqTask.Interfaces;
using System.Diagnostics;
using TestConsole;

namespace ParallelLinqTask
{
    public class ParallelLinq : IInformationSought
    {
        public IEnumerable<T> GetSortCollection<T>(IEnumerable<T> collection, Func<T, bool> predicate) where T : Unit
        {
            var rez = collection.AsParallel().Where(predicate);

            return rez;
        }
    }
}
