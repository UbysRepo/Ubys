//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Prism
{
    using Common.Protocol.Network.Types.Game.Character;
    using Common.Protocol.Network;
    using System.Collections.Generic;
    using System;
    
    
    public class PrismFightAttackerAddMessage : NetworkMessage
    {
        
        public const int Id = 5893;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private ushort m_subAreaId;
        
        public virtual ushort SubAreaId
        {
            get
            {
                return m_subAreaId;
            }
            set
            {
                m_subAreaId = value;
            }
        }
        
        private ushort m_fightId;
        
        public virtual ushort FightId
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
        
        private CharacterMinimalPlusLookInformations m_attacker;
        
        public virtual CharacterMinimalPlusLookInformations Attacker
        {
            get
            {
                return m_attacker;
            }
            set
            {
                m_attacker = value;
            }
        }
        
        public void Initiate(ushort subAreaId, ushort fightId, CharacterMinimalPlusLookInformations attacker)
        {
            m_subAreaId = subAreaId;
            m_fightId = fightId;
            m_attacker = attacker;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarUhShort(m_subAreaId);
            writer.WriteVarUhShort(m_fightId);
            writer.WriteUShort(((ushort)(m_attacker.ProtocolId)));
            m_attacker.Serialize(writer);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_subAreaId = reader.ReadVarUhShort();
            m_fightId = reader.ReadVarUhShort();
            m_attacker = ProtocolManager.GetTypeInstance<CharacterMinimalPlusLookInformations>(reader.ReadUShort());
            m_attacker.Deserialize(reader);
        }
    }
}
