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
    
    
    public class GuildFactsRequestMessage : NetworkMessage
    {
        
        public const int Id = 6404;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private uint m_guildId;
        
        public virtual uint GuildId
        {
            get
            {
                return m_guildId;
            }
            set
            {
                m_guildId = value;
            }
        }
        
        public void Initiate(uint guildId)
        {
            m_guildId = guildId;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarUhInt(m_guildId);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_guildId = reader.ReadVarUhInt();
        }
    }
}
