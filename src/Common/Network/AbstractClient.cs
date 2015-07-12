using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Common.Network
{
    /// <summary>
    /// Objet constituant la base d'un client Tcp.
    /// </summary>
    public abstract class AbstractClient : IDisposable
    {
        #region Fields
        private Socket _socket;
        private byte[] _buffer;
        private bool _disconnected;
        public static event Action<AbstractClient> Disconnected;
        #endregion

        #region Properties
        public bool Connected
        {
            get { return _socket != null && _socket.Connected; }
        }
        #endregion

        #region Constructor
        public AbstractClient(Socket socket)
        {
            _socket = socket;
            _buffer = new byte[512];

            StartReceive();
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Déconnexion du client.
        /// </summary>
        public void Disconnect()
        {
            if (_disconnected)
            {
                return;
            }
            _disconnected = true;

            _socket.Close();

            OnDisconnected();

            var disconnected = Disconnected;
            if (disconnected != null)
            {
                disconnected(this);
            }
        }
        /// <summary>
        /// Libère les ressources du client.
        /// </summary>
        public virtual void Dispose()
        {
            this._socket.Close();
            this._socket = null;

            this._buffer = null;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Début de la réception de donées.
        /// </summary>
        private void StartReceive()
        {
            if (!Connected)
            {
                return;
            }

            try
            {
                _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, OnReceive, null);
            }
            catch (Exception)
            {//TODO log exception
            }
        }
        /// <summary>
        /// Reception d'un packet
        /// </summary>
        /// <param name="ar"></param>
        private void OnReceive(IAsyncResult ar)
        {
            if (!Connected)
            {
                Disconnect();
                return;
            }

            var length = 0;

            try
            {
                length = _socket.EndReceive(ar);
            }
            catch (Exception)
            {//TODO log exception
            }

            if (length == 0)
            {
                Disconnect();
                return;
            }

            //parse packet

            OnReceived();

            StartReceive();
        }
        #endregion

        #region Protected methods
        protected abstract void OnReceived(/*message*/);
        protected abstract void OnDisconnected();
        #endregion
    }
}
