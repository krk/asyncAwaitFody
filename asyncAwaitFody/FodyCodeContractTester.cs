using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace asyncAwaitFody
{
    [PropertyChanged.ImplementPropertyChanged]
    public class FodyCodeContractTester
    {
        public string Abc { get; set; }

        public static void Main()
        {
            Console.WriteLine("Hello World!");

            var t = Level1();
            var result = t.Result;

            Console.WriteLine(result);
        }

        public static async Task<int> Level1()
        {
            int a = 5;
            double b = 6;

            return await Level2(b);
        }

        public static async Task<int> Level2(double param1)
        {
            Contract.Requires(param1 == 6);

            int a = 5;
            double b = 6;

            return await Level3(param1, a);
        }

        public static async Task<int> Level3(double param1, int param2)
        {
            int a = 5;
            double b = 6;

            return await Level4(param1, param2);
        }

        private static async Task<int> Level4(double param1, int param2)
        {
            var t = Task.Factory.StartNew(() => 7);

            return await t;
        }
    }
}
