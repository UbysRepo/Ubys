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
    public class AuthServer : Singleton<AuthServer>, IDisposable
    {
        private NetworkAcceptor _acceptor;
        private List<AuthClient> _clients;

        public AuthServer()
        {
            _acceptor = new NetworkAcceptor();
            _clients = new List<AuthClient>();
        }

        /// <summary>
        /// Lancement du server
        /// </summary>
        public void Initialize()
        {
            if (!_acceptor.Bind(Configuration.IPAddress, Configuration.Port))
            {//exit or throw something
            }

            if (!_acceptor.Listen())
            {//exit or throw something
            }

            Console.WriteLine("Listening to {0}:{1}", Configuration.IPAddress, Configuration.Port);

            AuthClient.Disconnected += OnDisconnected;
            _acceptor.Accepted += OnAccepted;
        }

        /// <summary>
        /// Arret du server
        /// </summary>
        public void Stop()
        {
            _acceptor.Stop();
            _acceptor.Accepted -= OnAccepted;
            AuthClient.Disconnected -= OnDisconnected;

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
        private void OnAccepted(Socket socket)
        {
            Console.WriteLine("incoming connection {0}", socket.RemoteEndPoint.ToString());

            var client = new AuthClient(socket);

            lock (_clients)
            {
                _clients.Add(client);
            }
        }

        /// <summary>
        /// Deconnection d'un client
        /// </summary>
        /// <param name="client"></param>
        private void OnDisconnected(AbstractClient client)
        {
            client.Dispose();

            lock (_clients)
            {
                _clients.Remove(client as AuthClient);
            }
        }

        public void Dispose()
        {
            _acceptor.Dispose();
        }
    }
}
