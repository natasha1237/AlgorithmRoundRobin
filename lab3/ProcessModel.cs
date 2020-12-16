using System;

namespace lab3
{
    public class ProcessModel: IComparable
    {
            public string Name { get; set; }
            public int Time { get; set; }
            public int Priority { get; set; }

            public bool Completed = false;
       
            public int CompareTo(object obj)
            {
                ProcessModel pm = obj as ProcessModel;
                if (pm != null)
                    return this.Priority.CompareTo(pm.Priority);
                else
                    throw new Exception("Can't compare");
            }

            public override string ToString()
            {
                return $"Name: {this.Name}\t Time: {this.Time}\t Priority: {this.Priority}";
            }

    }
}
