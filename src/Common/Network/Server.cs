using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

//Exteral using.

namespace Common.Network
{
    public class Server
    {
        #region Fields
        private TcpListener _listener;
        #endregion

        #region Properties
        #endregion

        #region Builder
        public Server(IPAddress ip, int port)
        {
            this._listener = new TcpListener(ip, port);

        }
        #endregion

        #region Private methods
        public virtual async Task<TcpClient> AcceptClients()
        {
            while (true)
            {
                try
                {
                    return await this._listener.AcceptTcpClientAsync();
                }
                catch
                {

                }
            }
        }
        #endregion 

        #region Public methods
        public void Start()
        {
            this._listener.Start();

        }
        #endregion
    }
}
