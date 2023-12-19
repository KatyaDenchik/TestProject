﻿using ParallelLinqTask;
using ParallelLinqTask.Interfaces;
using System;
using System.Diagnostics;

namespace TestConsole
{
    public class Unit
    {
        public string name;
        public string Name
        {
            get
            {
                Task.Delay(TimeSpan.FromSeconds(2)).Wait();
                return name;
            }

            set => name = value;
        }
        private bool isExist;
        public bool IsExist
        {
            get
            {
                Task.Delay(TimeSpan.FromSeconds(2)).Wait();
                return isExist;
            }

            set => isExist = value;
        }
    }


    internal class Program
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
        static void Main(string[] args)
        {
            //вывести имена всех присутствующих юнитов (где IsExist = true)
            //найти в листе zeta и прервать поиск после нахождения (написать zeta найдена "номер итерации цикла", используй foreach)
            //сделать обычными средствами и с использованием параллельных вычеслений (Linq и класс Parallel)
            //вывести время выполнения последовательной и параллельной логики например: последовательный поиск всех присутствующих юнитов потратил n.nnn секунд


            IInformationSought simpleOutput = new SimpleLinq();
            IInformationSought parallelOutput = new ParallelLinq();

            Console.WriteLine("Обычный linq");
            var rezSimpleLinq = simpleOutput.GetSortCollection(Units, unit => unit.IsExist);
            rezSimpleLinq.Select(unit => unit.Name).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("\n");

            Console.WriteLine("Parallel linq");
            var rezParallelLinq = parallelOutput.GetSortCollection(Units, unit => unit.IsExist);
            rezParallelLinq.Select(unit => unit.Name).ToList().ForEach(Console.WriteLine);
        }
    }
}