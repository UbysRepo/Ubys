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
        private bool _running;

        public AuthServer()
        {
            _acceptor = new NetworkAcceptor();
            _clients = new List<AuthClient>();
        }

        public void Initialize()
        {
            if (!_acceptor.Bind(Configuration.IPAddress, Configuration.Port))
            {//exit or throw something
            }

            if (!_acceptor.Listen())
            {//exit or throw something
            }

            Console.WriteLine("Listening to {0}:{1}", Configuration.IPAddress, Configuration.Port);

            _running = true;
            _acceptor.Accepted += OnAccepted;
        }

        public void Stop()
        {
            _acceptor.Stop();
            _acceptor.Accepted -= OnAccepted;

            _running = false;

            foreach (var client in _clients)
            {
                client.Disconnect();
            }
            _clients.Clear();
        }

        private void OnAccepted(Socket socket)
        {
            Console.WriteLine("incoming connection {0}", socket.RemoteEndPoint.ToString());

            var client = new AuthClient(socket);
            client.Disconnected += OnDisconnected;

            lock (_clients)
            {
                _clients.Add(client);
            }
        }

        private void OnDisconnected(AbstractClient client)
        {
            client.Disconnected -= OnDisconnected;
            client.Dispose();

            if (_running)
            {
                lock (_clients)
                {
                    _clients.Remove(client as AuthClient);
                }
            }
        }

        public void Dispose()
        {
            _acceptor.Dispose();
        }
    }
}
