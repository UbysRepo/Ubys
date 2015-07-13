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
    
    
    public class TeleportToBuddyOfferMessage : NetworkMessage
    {
        
        public const int Id = 6287;
        
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
        
        private uint m_timeLeft;
        
        public virtual uint TimeLeft
        {
            get
            {
                return m_timeLeft;
            }
            set
            {
                m_timeLeft = value;
            }
        }
        
        public void Initiate(ushort dungeonId, uint buddyId, uint timeLeft)
        {
            m_dungeonId = dungeonId;
            m_buddyId = buddyId;
            m_timeLeft = timeLeft;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarUhShort(m_dungeonId);
            writer.WriteVarUhInt(m_buddyId);
            writer.WriteVarUhInt(m_timeLeft);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_dungeonId = reader.ReadVarUhShort();
            m_buddyId = reader.ReadVarUhInt();
            m_timeLeft = reader.ReadVarUhInt();
        }
    }
}
