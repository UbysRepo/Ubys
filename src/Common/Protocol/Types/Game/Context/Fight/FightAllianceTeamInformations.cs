//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Types.Game.Context.Fight
{
    using System.Collections.Generic;
    using System;
    
    
    public class FightAllianceTeamInformations : FightTeamInformations
    {
        
        public const int Id = 439;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private byte m_relation;
        
        public virtual byte Relation
        {
            get
            {
                return m_relation;
            }
            set
            {
                m_relation = value;
            }
        }
        
        public void Initiate(byte relation)
        {
            m_relation = relation;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(m_relation);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            m_relation = reader.ReadByte();
        }
    }
}
