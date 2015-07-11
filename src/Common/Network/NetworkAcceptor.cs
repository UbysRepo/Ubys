using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

//Exteral using.

namespace Common.Network
{
    /// <summary>
    /// Type modélisant un serveur Tcp de base.
    /// </summary>
    public class NetworkAcceptor : IDisposable
    {
        private readonly Socket _socket;
        private bool _running;

        public event Action<Socket> Accepted;

        public NetworkAcceptor()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public bool Bind(string address, ushort port)
        {
            IPAddress ip;
            if (!IPAddress.TryParse(address, out ip))
            {
                ip = Dns.GetHostEntry(address).AddressList.FirstOrDefault();
            }

            if (ip == null)
            {//TODO log invalid address
                return false;
            }

            try
            {
                _socket.Bind(new IPEndPoint(ip, port));
            }
            catch (Exception)
            {//TODO log the exception
                return false;
            }

            return true;
        }

        public bool Listen()
        {
            try
            {
                _socket.Listen(5);
                _socket.NoDelay = true;
                _running = true;
                StartAccept();
            }
            catch (Exception)
            {//TODO log the exception
                return false;
            }
            return true;
        }

        public void Stop()
        {
            _running = false;
            _socket.Close();
        }

        private void StartAccept()
        {
            if (!_running)
            {
                return;
            }
            _socket.BeginAccept(OnAccept, null);
        }

        private void OnAccept(IAsyncResult ar)
        {
            if (!_running)
            {
                return;
            }

            Socket socket = null;

            try
            {
                socket = _socket.EndAccept(ar);
            }
            catch (Exception)
            {//TODO log exception
            }

            if (socket != null)
            {
                var accepted = Accepted;
                if (accepted != null)
                {
                    accepted(socket);
                }
            }

            StartAccept();
        }
    
        public void Dispose()
        {
            _socket.Close();
        }
    }
}
