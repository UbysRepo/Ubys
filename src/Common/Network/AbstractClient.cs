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
    public class AbstractClient : IDisposable
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

            this.Read();
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Fonction virtuelle permettant de récupérer le paquet reçu.
        /// "Overrider" dans chaque héritage de ce type.
        /// </summary>
        /// <returns>Retourne le paquet(byte[]) reçu.</returns>
        protected virtual async Task<byte[]> Read()
        {
            byte[] buffer;

            while (this.IsConnected)
            {
                try
                {
                    buffer = new byte[this._socket.Available];
                    await this._stream.ReadAsync(buffer, 0, buffer.Length);
                    
                    return buffer;
                }
                catch
                {
                    Dispose();
                    return null;
                }
            }
            Dispose();
            return null;
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
    }
}
