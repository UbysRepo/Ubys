//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Inventory.Items
{
    using System.Collections.Generic;
    using System;
    
    
    public class ObjectUseMultipleMessage : ObjectUseMessage
    {
        
        public const int Id = 6234;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private uint m_quantity;
        
        public virtual uint Quantity
        {
            get
            {
                return m_quantity;
            }
            set
            {
                m_quantity = value;
            }
        }
        
        public void Initiate(uint quantity)
        {
            m_quantity = quantity;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(m_quantity);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            m_quantity = reader.ReadVarUhInt();
        }
    }
}
