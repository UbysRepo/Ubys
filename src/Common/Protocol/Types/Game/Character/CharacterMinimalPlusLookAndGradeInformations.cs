//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Types.Game.Character
{
    using Common.Protocol.Network.Types.Game.Look;
    using System.Collections.Generic;
    using System;
    
    
    public class CharacterMinimalPlusLookAndGradeInformations : CharacterMinimalPlusLookInformations
    {
        
        public const int Id = 193;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private uint m_grade;
        
        public virtual uint Grade
        {
            get
            {
                return m_grade;
            }
            set
            {
                m_grade = value;
            }
        }
        
        public void Initiate(uint grade)
        {
            m_grade = grade;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(m_grade);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            m_grade = reader.ReadVarUhInt();
        }
    }
}
