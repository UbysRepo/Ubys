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
    
    
    public class GuildMemberOnlineStatusMessage : NetworkMessage
    {
        
        public const int Id = 6061;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private uint m_memberId;
        
        public virtual uint MemberId
        {
            get
            {
                return m_memberId;
            }
            set
            {
                m_memberId = value;
            }
        }
        
        private bool m_online;
        
        public virtual bool Online
        {
            get
            {
                return m_online;
            }
            set
            {
                m_online = value;
            }
        }
        
        public void Initiate(uint memberId, bool online)
        {
            m_memberId = memberId;
            m_online = online;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarUhInt(m_memberId);
            writer.WriteBoolean(m_online);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_memberId = reader.ReadVarUhInt();
            m_online = reader.ReadBoolean();
        }
    }
}
