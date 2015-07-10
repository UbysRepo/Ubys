using Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Protocol
{
    /// <summary>
    /// Type permettant de vivre 
    /// </summary>
    class ProtocolManager
    {
        #region Fields
        private Dictionary<uint, MethodInfo> _protocolHandler;
        #endregion

        #region Properties

        #endregion

        #region Constructor
        public ProtocolManager()
        {

        }
        #endregion

        #region Public methods
        public void Parse(Client client, byte[] buffer)
        {

        }
        #endregion

        #region Private methods

        #endregion
        
    }
}
