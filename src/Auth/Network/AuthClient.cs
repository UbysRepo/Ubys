using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

//External using.
using Common.Network;

namespace Auth.Network
{
    class AuthClient : Client
    {
        #region Fields

        #endregion

        #region Properties
        public TcpClient Socket { get; set; }
        #endregion

        #region Builder
        /// <summary>
        /// Client de connexion , il contiendra toutes les informations du connécté : compte, personnages, etc
        /// </summary>
        /// <param name="sock"></param>
        public AuthClient(TcpClient sock)
            : base(sock)
        {
            this.Socket = sock;
        }
        #endregion

        #region Private methods

        #endregion

        #region Public methods

        #endregion
    }
}
