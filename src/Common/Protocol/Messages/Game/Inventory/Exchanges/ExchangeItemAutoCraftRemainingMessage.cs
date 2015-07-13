//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using System.Collections.Generic;
    using System;
    
    
    public class ExchangeItemAutoCraftRemainingMessage : NetworkMessage
    {
        
        public const int Id = 6015;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private uint m_count;
        
        public virtual uint Count
        {
            get
            {
                return m_count;
            }
            set
            {
                m_count = value;
            }
        }
        
        public void Initiate(uint count)
        {
            m_count = count;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarUhInt(m_count);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_count = reader.ReadVarUhInt();
        }
    }
}
