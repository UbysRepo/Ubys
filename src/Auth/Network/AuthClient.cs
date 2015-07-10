using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

//External using.
using Common.Network;
using System.Threading;

namespace Auth.Network
{
    class AuthClient : Client
    {
        #region Fields
        
        #endregion

        #region Properties

        #endregion

        #region Constructor
        public AuthClient(TcpClient sock)
            : base(sock)
        {

        }
        #endregion

        #region Private methods
        private void Read()
        {
            byte[] buffer = base.Read().Result;

        }
        #endregion

        #region Public methods

        #endregion
    }
}
