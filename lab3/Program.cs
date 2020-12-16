using System;
using System.Collections.Generic;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ProcessModel> processes = new List<ProcessModel>();
            processes.Add(new ProcessModel
            {
                Time = 21,
                Name = "Process1",
                Priority = 2
            });
            processes.Add(new ProcessModel
            {
                Time = 21,
                Name = "Process2",
                Priority = 3
            });
            processes.Add(new ProcessModel
            {
                Time = 21,
                Name = "Process3",
                Priority = 2
            });
            processes.Add(new ProcessModel
            {
                Time = 21,
                Name = "Process4",
                Priority = 4
            });
            processes.Add(new ProcessModel
            {
                Time = 21,
                Name = "Process5",
                Priority = 1
            });

            int[] processesId = new int[processes.Count];

            int n = processesId.Length;

            int[] burst_time = new int[processes.Count];

            int k = 0;

            foreach (var item in processes)
            {
                burst_time[k] = item.Time;
                k++;
            }

            int quantum = 3;

            processes.Sort();

            foreach (var i in processes)
            {
                Console.WriteLine(i);
            }

            AlgorithmRoundRobin alg = new AlgorithmRoundRobin(2);

            alg.ProcessInit(processes);
            alg.ManageProcess();
            alg.findavgTime(processesId, n, burst_time, quantum);

            Console.ReadKey();
        }
    }
}
