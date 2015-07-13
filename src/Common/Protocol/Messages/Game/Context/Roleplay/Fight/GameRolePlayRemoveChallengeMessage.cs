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
    
    
    public class GameRolePlayRemoveChallengeMessage : NetworkMessage
    {
        
        public const int Id = 300;
        
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
        
        public void Initiate(int fightId)
        {
            m_fightId = fightId;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteInt(m_fightId);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_fightId = reader.ReadInt();
        }
    }
}
