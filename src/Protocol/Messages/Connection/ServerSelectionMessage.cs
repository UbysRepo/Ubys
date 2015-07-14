//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Protocol.Messages.Connection
{
    using System.Collections.Generic;
    using System;
    using Protocol.IO.BigEndian;
    using Protocol.Messages;
    
    public class ServerSelectionMessage : AbstractAbstractNetworkMessage
    {
        
        public const int Id = 40;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private ushort m_serverId;
        
        public virtual ushort ServerId
        {
            get
            {
                return m_serverId;
            }
            set
            {
                m_serverId = value;
            }
        }
        
        public void Initiate(ushort serverId)
        {
            m_serverId = serverId;
        }
        
        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteVarUhShort(m_serverId);
        }
        
        public override void Deserialize(BigEndianReader reader)
        {
            m_serverId = reader.ReadVarUhShort();
        }
    }
}
