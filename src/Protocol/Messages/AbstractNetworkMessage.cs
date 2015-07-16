using Protocol.IO.BigEndian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Messages
{
    public abstract class AbstractNetworkMessage
    {
        #region Properties
        public abstract int ProtocolId 
        { 
            get; 
        }
        #endregion

        #region Public methods
        public abstract void Serialize(BigEndianWriter writer);

        public abstract void Deserialize(BigEndianReader reader);
        #endregion
    }
}
