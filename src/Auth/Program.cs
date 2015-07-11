using Auth.Network;
using Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press ctrl-c to stop");
            Console.CancelKeyPress += OnCancelKeyPressed;
            AuthServer.Instance.Initialize();


            Console.ReadLine();
        }

        static void OnCancelKeyPressed(object sender, ConsoleCancelEventArgs e)
        {
            AuthServer.Instance.Stop();
            AuthServer.Instance.Dispose();
            Console.WriteLine("Server stopped");
        }
    }
}
