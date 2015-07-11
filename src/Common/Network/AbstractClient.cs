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
        protected Socket _socket;
        private byte[] buffer;
        #endregion 

        #region Properties
        public IPAddress Ip
        {
            get;
            private set;
        }
        public int Port
        {
            get;
            private set;
        }
        #endregion

        #region Constructor
        public AbstractClient(Socket listener, Socket sock)
        {
            this._socket = sock;

            var ipEndPoint = (IPEndPoint)sock.RemoteEndPoint;
            this.Ip = ipEndPoint.Address;
            this.Port = ipEndPoint.Port;

            this.StartReceive();
        }
        #endregion

        #region Private methods
        /// <summary>
        /// (asynchrone.)
        /// Méthode permettant de récupérer les données reçues.
        /// </summary>
        private void StartReceive()
        {
            try
            {
                this.buffer = new byte[this._socket.Available];
                this._socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(EndReceive), null);
            }
            catch
            {
                //todo: logs.
            }
        }
        #endregion

        #region Protected methods
        /// <summary>
        /// Méthode abstract permettant d'être overrider
        /// pour le traitement des données reçues.
        /// </summary>
        protected abstract void EndReceive(IAsyncResult ar);
        #endregion

        #region Public methods
        public virtual void Dispose()
        {
            this._socket.Disconnect(false);
            this._socket.Dispose();

            this.Ip = null;
            this.Port = 0;
        }
        #endregion
    }
}
