//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Context.Roleplay.Houses
{
    using System.Collections.Generic;
    using System;
    
    
    public class HouseBuyRequestMessage : NetworkMessage
    {
        
        public const int Id = 5738;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private uint m_proposedPrice;
        
        public virtual uint ProposedPrice
        {
            get
            {
                return m_proposedPrice;
            }
            set
            {
                m_proposedPrice = value;
            }
        }
        
        public void Initiate(uint proposedPrice)
        {
            m_proposedPrice = proposedPrice;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarUhInt(m_proposedPrice);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_proposedPrice = reader.ReadVarUhInt();
        }
    }
}
