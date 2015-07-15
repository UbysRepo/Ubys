//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using Protocol.IO.BigEndian;
using Protocol.Types.Connection;

namespace Protocol.Messages.Connection
{
    
    
    
    public class ServerStatusUpdateMessage : AbstractAbstractNetworkMessage
    {
        
        public const int Id = 50;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private GameServerInformations m_server;
        
        public virtual GameServerInformations Server
        {
            get
            {
                return m_server;
            }
            set
            {
                m_server = value;
            }
        }
        
        public void Initiate(GameServerInformations server)
        {
            m_server = server;
        }
        
        public override void Serialize(BigEndianWriter writer)
        {
            m_server.Serialize(writer);
        }
        
        public override void Deserialize(BigEndianReader reader)
        {
            m_server = new GameServerInformations();
            m_server.Deserialize(reader);
        }
    }
}
