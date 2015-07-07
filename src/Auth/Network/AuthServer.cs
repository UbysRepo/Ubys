using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//External using
using Common.Network;
using System.Net.Sockets;
using System.Net;
namespace Auth.Network
{
    class AuthServer : Server
    {
        #region Contructor 
        public AuthServer(IPAddress ip,int port):base(ip,port)
        {

        }
        #endregion
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Builder

        #endregion

        #region Public methods
        public AuthClient AcceptConnection()
        {
            TcpClient Sock = base.AcceptClients().Result;
            return new AuthClient(Sock);
        }
        #endregion

        #region Private methods
        #endregion
    }
}
