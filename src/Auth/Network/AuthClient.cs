using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Common.Network;

namespace Auth.Network
{
    public class AuthClient : AbstractClient
    {
        public AuthClient(Socket socket)
            : base(socket)
        {
        }

        protected override void OnReceived()
        {
            Console.WriteLine("Received");
        }

        protected override void OnDisconnected()
        {
            Console.WriteLine("Disconnected");
        }
    }
}
