using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new TimeService.TimeServiceClient();
            var time = a.GetCurrentTime();
            Console.WriteLine(time);

            //var a = new ;

            Console.ReadKey();
        }
    }
}
