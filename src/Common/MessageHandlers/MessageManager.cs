using Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Common.MessageHandlers
{
    /// <summary>
    /// Type permettant d'utiliser la méthode adaptée
    /// au handle d'un paquet reçu.
    /// </summary>
    class MessageManager
    {
        #region Fields
        private Dictionary<ushort, Action<AbstractClient, byte[]>> _protocolHandler;
        #endregion

        #region Properties

        #endregion

        #region Constructor
        public MessageManager()
        {

        }
        #endregion

        #region Public methods
        public void Handle(AbstractClient client, byte[] buffer)
        {

        }
        #endregion

        #region Private methods

        #endregion
        
    }
}
