
namespace DemoConsole
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SemanticLogging;

    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("Starting");

            Logger.Log.ApplicationStart();

            var Proc = new ProcessWithLogging();
            Proc.ProcessSomething();
        }
    }
}
