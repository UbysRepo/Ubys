//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Types.Game.Data.Items.Effects
{
    using System.Collections.Generic;
    using System;
    
    
    public class ObjectEffectLadder : ObjectEffectCreature
    {
        
        public const int Id = 81;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private uint m_monsterCount;
        
        public virtual uint MonsterCount
        {
            get
            {
                return m_monsterCount;
            }
            set
            {
                m_monsterCount = value;
            }
        }
        
        public void Initiate(uint monsterCount)
        {
            m_monsterCount = monsterCount;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(m_monsterCount);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            m_monsterCount = reader.ReadVarUhInt();
        }
    }
}
