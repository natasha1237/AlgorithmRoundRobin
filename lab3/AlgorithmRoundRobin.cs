using System;
using System.Collections.Generic;
using System.Linq;

namespace lab3
{
    class AlgorithmRoundRobin
    {
        public int Quant;

        public AlgorithmRoundRobin(int quant)
        {
            Quant = quant;
        }

        public List<ProcessModel> Processes;

        public void ProcessInit(List<ProcessModel> processes)
        {
            Processes = processes;
        }

        public void ManageProcess()
        {
            List<ProcessModel> list = new List<ProcessModel>();
            List<List<ProcessModel>> listsByPriotity;
            Processes.Sort();
            listsByPriotity = SplitIntoLists(Processes);

            foreach (var items in listsByPriotity)
            {
                foreach (var item in items)
                {
                    list.Add(item);
                }

                while (list.Count != 0)
                {
                    PrintList(list);
                    var elem = list.First();
                    elem.Time -= Quant;
                    if (elem.Time <= 0)
                    {
                        elem.Completed = true;
                        list.Remove(elem);
                    }
                    else
                    {
                        list.Remove(elem);
                        list.Add(elem);
                    }
                }
            }
        }

        public void PrintList(List<ProcessModel> list)
        {
            Console.WriteLine("Current list:");

            Console.WriteLine("--------------------------");
            foreach (var item in list)
            {
                Console.WriteLine($"Name: {item.Name}\t Time: {item.Time}");
            }
            Console.WriteLine("--------------------------");
        }
        // split by priorities
        public List<List<ProcessModel>> SplitIntoLists(List<ProcessModel> list)
        {
            List<List<ProcessModel>> listsByPriotity = new List<List<ProcessModel>>();
            var maxPriority = list.Max(m => m.Priority);
            for (int i = 1; i <= maxPriority; i++)
            {
                List<ProcessModel> temp = new List<ProcessModel>();
                temp = list.Where(s => s.Priority == i).ToList();
                if (temp.Count == 0)
                {
                    continue;
                }
                listsByPriotity.Add(temp);
            }
            return listsByPriotity;
        }

        static void TurnAroundTime(int[] processes, int n, int[] bt, int[] wt, int[] tat)
        {
            for (int i = 0; i < n; i++)
                tat[i] = bt[i] + wt[i];
        }

        // Waiting Time = Turn Around Time – Burst Time
        static void WaitingTime(int[] processes, int n, int[] bt, int[] wt, int quantum)
        {
            int[] rem_bt = new int[n];
            for (int i = 0; i < n; i++)
                rem_bt[i] = bt[i];
            int t = 0;
            while (true)
            {
                bool done = true;
                for (int i = 0; i < n; i++)
                {
                    if (rem_bt[i] > 0)
                    {
                        done = false;

                        if (rem_bt[i] > quantum)
                        {
                            t += quantum;
                            rem_bt[i] -= quantum;
                        }
                        else
                        {
                            t = t + rem_bt[i];
                            wt[i] = t - bt[i];
                            rem_bt[i] = 0;
                        }
                    }
                }
                if (done == true)
                    break;
            }
        }

        public void findavgTime(int[] processes, int n, int[] bt, int quantum)
        {
            int[] wt = new int[n];
            int[] tat = new int[n];
            int total_wt = 0, total_tat = 0;
            WaitingTime(processes, n, bt, wt, quantum);
            TurnAroundTime(processes, n, bt, wt, tat);
            Console.WriteLine("Processes " + " Burst time " + " Waiting time " + " Turn around time");
            for (int i = 0; i < n; i++)
            {
                total_wt = total_wt + wt[i];
                total_tat = total_tat + tat[i];
                Console.WriteLine(" " + (i + 1) + "\t\t" + bt[i] + "\t " + wt[i] + "\t\t " + tat[i]);
            }
            Console.WriteLine("Average waiting time = " + (float)total_wt / (float)n);
            Console.Write("Average turn around time = " + (float)total_tat / (float)n);
        }
    }
}
