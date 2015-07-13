//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Interactive
{
    using System.Collections.Generic;
    using System;
    
    
    public class InteractiveUseEndedMessage : NetworkMessage
    {
        
        public const int Id = 6112;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private uint m_elemId;
        
        public virtual uint ElemId
        {
            get
            {
                return m_elemId;
            }
            set
            {
                m_elemId = value;
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
        
        public void Initiate(uint elemId, ushort skillId)
        {
            m_elemId = elemId;
            m_skillId = skillId;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarUhInt(m_elemId);
            writer.WriteVarUhShort(m_skillId);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_elemId = reader.ReadVarUhInt();
            m_skillId = reader.ReadVarUhShort();
        }
    }
}
