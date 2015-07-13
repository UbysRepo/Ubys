//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Context.Roleplay.Fight
{
    using System.Collections.Generic;
    using System;
    
    
    public class GameRolePlayAggressionMessage : NetworkMessage
    {
        
        public const int Id = 6073;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private uint m_attackerId;
        
        public virtual uint AttackerId
        {
            get
            {
                return m_attackerId;
            }
            set
            {
                m_attackerId = value;
            }
        }
        
        private uint m_defenderId;
        
        public virtual uint DefenderId
        {
            get
            {
                return m_defenderId;
            }
            set
            {
                m_defenderId = value;
            }
        }
        
        public void Initiate(uint attackerId, uint defenderId)
        {
            m_attackerId = attackerId;
            m_defenderId = defenderId;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarUhInt(m_attackerId);
            writer.WriteVarUhInt(m_defenderId);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_attackerId = reader.ReadVarUhInt();
            m_defenderId = reader.ReadVarUhInt();
        }
    }
}
