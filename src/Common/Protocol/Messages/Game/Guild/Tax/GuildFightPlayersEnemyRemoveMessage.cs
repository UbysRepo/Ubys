//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Guild.Tax
{
    using System.Collections.Generic;
    using System;
    
    
    public class GuildFightPlayersEnemyRemoveMessage : NetworkMessage
    {
        
        public const int Id = 5929;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private int m_fightId;
        
        public virtual int FightId
        {
            get
            {
                return m_fightId;
            }
            set
            {
                m_fightId = value;
            }
        }
        
        private uint m_playerId;
        
        public virtual uint PlayerId
        {
            get
            {
                return m_playerId;
            }
            set
            {
                m_playerId = value;
            }
        }
        
        public void Initiate(int fightId, uint playerId)
        {
            m_fightId = fightId;
            m_playerId = playerId;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteInt(m_fightId);
            writer.WriteVarUhInt(m_playerId);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_fightId = reader.ReadInt();
            m_playerId = reader.ReadVarUhInt();
        }
    }
}
