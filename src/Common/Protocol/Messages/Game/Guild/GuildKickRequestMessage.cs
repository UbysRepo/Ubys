//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Guild
{
    using System.Collections.Generic;
    using System;
    
    
    public class GuildKickRequestMessage : NetworkMessage
    {
        
        public const int Id = 5887;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private uint m_kickedId;
        
        public virtual uint KickedId
        {
            get
            {
                return m_kickedId;
            }
            set
            {
                m_kickedId = value;
            }
        }
        
        public void Initiate(uint kickedId)
        {
            m_kickedId = kickedId;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarUhInt(m_kickedId);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_kickedId = reader.ReadVarUhInt();
        }
    }
}
