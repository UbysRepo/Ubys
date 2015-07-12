using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
//External using
using Common.Network;
using Common.Utils;
using Auth.Utils;

namespace Auth.Network
{
    public class AuthServer : AbstractServer<AuthServer, AuthClient>
    {
        public AuthServer()
            : base()
        {
        }

        /// <summary>
        /// Lancement du server
        /// </summary>
        public void Initialize()
        {
            base.Initialize(Configuration.IPAddress, Configuration.Port);

            Console.WriteLine("Listening to {0}:{1}", Configuration.IPAddress, Configuration.Port);
        }

        /// <summary>
        /// Arret du server
        /// </summary>
        public override void Stop()
        {
            base.Stop();

            foreach (var client in _clients)
            {
                client.Disconnect();
                client.Dispose();
            }
            _clients.Clear();
        }

        /// <summary>
        /// Connection d'un client
        /// </summary>
        /// <param name="socket"></param>
        protected override void OnAccepted(Socket socket)
        {
            base.OnAccepted(socket);

            Console.WriteLine("Incoming connection {0}", socket.RemoteEndPoint.ToString());
        }

        /// <summary>
        /// Deconnection d'un client
        /// </summary>
        /// <param name="client"></param>
        protected override void OnDisconnected(AbstractClient client)
        {
            base.OnDisconnected(client);

            Console.WriteLine("Client disconnected");

            client.Dispose();
        }

        /// <summary>
        /// Libère les ressources
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
