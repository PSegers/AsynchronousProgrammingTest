using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TAPTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DoSomethingClass bob = new DoSomethingClass();
            bob.DoSomething();
            

            Thread thread = new Thread(bob.DoSomething);
            Thread thread2 = new Thread(bob.Henky);
            thread.Start();
            thread2.Start();

            Console.ReadLine();

            /*Console.WriteLine("Begin");
            Thread.Sleep(5000);
            Console.WriteLine("Einde");
            Console.ReadLine();*/
        }
    }
}
