using MSM.Socketing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasPorConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Server s = Server.Instance;

            s.Init();

            Console.ReadKey();
        }
    }
}
