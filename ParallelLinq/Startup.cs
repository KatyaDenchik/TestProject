using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ParallelLinqTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole;

namespace ParallelLinqTask
{
    public class Startup : BackgroundService
    {
        private static List<Unit> Units = new()
        {
            new Unit{Name = "alpha", IsExist = false},
            new Unit{Name = "beta", IsExist = true},
            new Unit{Name = "gamma", IsExist = true},
            new Unit{Name = "delta", IsExist = false},
            new Unit{Name = "epsilon", IsExist = false},
            new Unit{Name = "zeta", IsExist = false},
            new Unit{Name = "eta", IsExist = true},
            new Unit{Name = "iota", IsExist = false},
            new Unit{Name = "kappa", IsExist = false},
            new Unit{Name = "lambda", IsExist = true},
            new Unit{Name = "mu", IsExist = true},
            new Unit{Name = "nu", IsExist = true},
            new Unit{Name = "xi", IsExist = true},
            new Unit{Name = "omicron", IsExist = false},
            new Unit{Name = "pi", IsExist = false},
            new Unit{Name = "rho", IsExist = false},
            new Unit{Name = "sigma", IsExist = true},
            new Unit{Name = "tau", IsExist = false},
            new Unit{Name = "upsilon", IsExist = true},
            new Unit{Name = "phi", IsExist = false},
            new Unit{Name = "chi", IsExist = false},
            new Unit{Name = "psi", IsExist = true},
            new Unit{Name = "omega", IsExist = true}
        };

        private readonly IInformationSought sorter;

        public Startup(IInformationSought sorter)
        {
            this.sorter = sorter;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Run(Start);
        }

        public void Start()
        {
            var rezSimpleLinq = sorter.GetSortCollection(Units, unit => unit.IsExist);
            rezSimpleLinq.AsParallel().ForAll(Unit => { Console.WriteLine(Unit.Name); });
        }
    }
}
