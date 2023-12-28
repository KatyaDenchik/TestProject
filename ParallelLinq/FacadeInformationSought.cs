using ParallelLinqTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole;

namespace ParallelLinqTask
{
    public class FacadeInformationSought : IInformationSought
    {
        private readonly IInformationSought linq;
        private readonly ILogger loggingToTxt;

        public FacadeInformationSought(IInformationSought linq, ILogger loggingToTxt)
        {
            this.linq = linq;
            this.loggingToTxt = loggingToTxt;
        }

        public IEnumerable<T> GetSortCollection<T>(IEnumerable<T> collection, Func<T, bool> predicate) where T : Unit
        {
            var sortedCollection = linq.GetSortCollection(collection, predicate).ToList();

            loggingToTxt.LogToTxt(sortedCollection);

            return sortedCollection;
        }
    }
}
