using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole;

namespace ParallelLinqTask.Interfaces
{
    public interface ILogger
    {
        void LogToTxt<T>(IEnumerable<T> collection) where T : Unit;
    }
}
