using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
//External using
using Common.Network;

namespace Auth.Network
{
    class AuthServer : AbstractServer
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Constructor

        #endregion

        #region Public methods
        #endregion

        #region Private methods
        protected override void EndAcceptClient(TcpClient sock)
        {
            new AuthClient(sock);
        }
        #endregion
    }
}
