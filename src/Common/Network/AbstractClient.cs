using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Common.Network
{
    /// <summary>
    /// Objet constituant la base d'un client Tcp.
    /// </summary>
    public abstract class AbstractClient : IDisposable
    {
        #region Fields
        protected TcpClient _socket;
        protected NetworkStream _stream;
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
        public bool IsConnected
        {
            get
            {
                return this._socket.Client.Connected;
            }
        }
        #endregion

        #region Constructor
        public AbstractClient(TcpClient sock)
        {
            this._socket = sock;
            this._stream = new NetworkStream(this._socket.Client);

            var ipEndPoint = (IPEndPoint)sock.Client.RemoteEndPoint;
            this.Ip = ipEndPoint.Address;
            this.Port = ipEndPoint.Port;

            this.Receive();
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Fonction permettant
        /// </summary>
        private async void Receive()
        {
            byte[] buffer;
            while (true)
            {
                try
                {
                    buffer = new byte[this._socket.Available];
                    await this._stream.ReadAsync(buffer, 0, buffer.Length);
                    this.HandleDatas(buffer);
                }
                catch
                {
                    //todo: logs.
                }
            }
        }
        #endregion

        #region Public methods
        public virtual void Dispose()
        {
            this._socket.Close();
            this._stream.Close();

            this.Ip = null;
            this.Port = 0;
        }
        #endregion

        #region Protected methods
        protected abstract void HandleDatas(byte[] buffer);
        #endregion
    }
}
