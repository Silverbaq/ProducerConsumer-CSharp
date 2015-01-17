using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Model;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Model.Buffer buffer = new Model.Buffer(10);
            Producer producer = new Producer(buffer);
            Consumer consumer = new Consumer(buffer);
            Producer producer2 = new Producer(buffer);
            Consumer consumer2 = new Consumer(buffer);

            Thread thread1 = new Thread(producer.Produce);
            Thread thread2 = new Thread(consumer.Consume);
            Thread thread3 = new Thread(producer2.Produce);
            Thread thread4 = new Thread(consumer2.Consume);



            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
        }
    }
}
