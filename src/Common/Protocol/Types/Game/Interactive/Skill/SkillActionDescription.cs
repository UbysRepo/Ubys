//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Types.Game.Interactive.Skill
{
    using System.Collections.Generic;
    using System;
    
    
    public class SkillActionDescription : NetworkType
    {
        
        public const int Id = 102;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private ushort m_skillId;
        
        public virtual ushort SkillId
        {
            get
            {
                return m_skillId;
            }
            set
            {
                m_skillId = value;
            }
        }
        
        public void Initiate(ushort skillId)
        {
            m_skillId = skillId;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarUhShort(m_skillId);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_skillId = reader.ReadVarUhShort();
        }
    }
}
