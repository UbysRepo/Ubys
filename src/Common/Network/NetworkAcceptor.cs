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
    /// Classe pour accepter de nouvelles connections
    /// </summary>
    public class NetworkAcceptor : IDisposable
    {
        private readonly Socket _socket;
        private bool _running;

        /// <summary>
        /// event de connection
        /// </summary>
        public event Action<Socket> Accepted;

        public NetworkAcceptor()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        /// <summary>
        /// Bind le socket
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Commencer l'ecoute
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Stopper l'ecoute
        /// </summary>
        public void Stop()
        {
            _running = false;
            _socket.Close();
        }

        /// <summary>
        /// Commencer a accepter de nouveaux sockets
        /// </summary>
        private void StartAccept()
        {
            if (!_running)
            {
                return;
            }
            _socket.BeginAccept(OnAccept, null);
        }

        /// <summary>
        /// Un socket va être accepter !
        /// </summary>
        /// <param name="ar"></param>
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
    
        /// <summary>
        /// Liberer les ressources
        /// </summary>
        public void Dispose()
        {
            _socket.Close();
        }
    }
}
