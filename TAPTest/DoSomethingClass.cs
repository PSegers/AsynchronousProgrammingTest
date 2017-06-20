using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TAPTest
{
    public class DoSomethingClass
    {
        public async void DoSomething()
        {
            Console.WriteLine("Begin");
            string name = await DoSmtElse();
            Console.WriteLine(name);
        }

        public Task<String> DoSmtElse()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(5000);
                return "string";
            }
                );
        }

        public void Henky()
        {
            Console.WriteLine("Henky");
        }
    }
}
