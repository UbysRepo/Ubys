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
    
    
    public class ExchangeIsReadyMessage : NetworkMessage
    {
        
        public const int Id = 5509;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private uint m_ObjectId;
        
        public virtual uint ObjectId
        {
            get
            {
                return m_ObjectId;
            }
            set
            {
                m_ObjectId = value;
            }
        }
        
        private bool m_ready;
        
        public virtual bool Ready
        {
            get
            {
                return m_ready;
            }
            set
            {
                m_ready = value;
            }
        }
        
        public void Initiate(uint objectId, bool ready)
        {
            m_ObjectId = objectId;
            m_ready = ready;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarUhInt(m_ObjectId);
            writer.WriteBoolean(m_ready);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_ObjectId = reader.ReadVarUhInt();
            m_ready = reader.ReadBoolean();
        }
    }
}
