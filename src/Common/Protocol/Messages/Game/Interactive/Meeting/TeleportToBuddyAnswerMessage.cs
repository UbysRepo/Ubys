//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Interactive.Meeting
{
    using System.Collections.Generic;
    using System;
    
    
    public class TeleportToBuddyAnswerMessage : NetworkMessage
    {
        
        public const int Id = 6293;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private ushort m_dungeonId;
        
        public virtual ushort DungeonId
        {
            get
            {
                return m_dungeonId;
            }
            set
            {
                m_dungeonId = value;
            }
        }
        
        private uint m_buddyId;
        
        public virtual uint BuddyId
        {
            get
            {
                return m_buddyId;
            }
            set
            {
                m_buddyId = value;
            }
        }
        
        private bool m_accept;
        
        public virtual bool Accept
        {
            get
            {
                return m_accept;
            }
            set
            {
                m_accept = value;
            }
        }
        
        public void Initiate(ushort dungeonId, uint buddyId, bool accept)
        {
            m_dungeonId = dungeonId;
            m_buddyId = buddyId;
            m_accept = accept;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarUhShort(m_dungeonId);
            writer.WriteVarUhInt(m_buddyId);
            writer.WriteBoolean(m_accept);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_dungeonId = reader.ReadVarUhShort();
            m_buddyId = reader.ReadVarUhInt();
            m_accept = reader.ReadBoolean();
        }
    }
}
