# Algorithm Round Robin
Round-robin (RR) is one of the algorithms employed by process and network schedulers in computing. As the term is generally used, time slices (also known as time quanta) are assigned to each process in equal portions and in circular order, handling all processes without priority (also known as cyclic executive). Round-robin scheduling is simple, easy to implement, and starvation-free. Round-robin scheduling can be applied to other scheduling problems, such as data packet scheduling in computer networks. It is an operating system concept.

## Умова 

```C#
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
```
### Process5  Time: 21 Priority: 1
### Process1  Time: 21 Priority: 2
### Process3  Time: 21 Priority: 2
### Process2  Time: 21 Priority: 3
### Process4  Time: 21 Priority: 4
           
### Починаємо процес Process5 
![alt text](https://github.com/natasha1237/AlgorithmRoundRobin/blob/main/1.png)
           
### Процес Process1 і Process3
![alt text](https://github.com/natasha1237/AlgorithmRoundRobin/blob/main/2.png)
![alt text](https://github.com/natasha1237/AlgorithmRoundRobin/blob/main/2.1.png)
![alt text](https://github.com/natasha1237/AlgorithmRoundRobin/blob/main/2.2.png)
           
### Процес Process2
![alt text](https://github.com/natasha1237/AlgorithmRoundRobin/blob/main/3.png)
          
### Процес Process4
![alt text](https://github.com/natasha1237/AlgorithmRoundRobin/blob/main/4.png)
           
### Результати
![alt text](https://github.com/natasha1237/AlgorithmRoundRobin/blob/main/5.png)
           
### Графік
![alt text](https://github.com/natasha1237/AlgorithmRoundRobin/blob/main/diagram.png)
