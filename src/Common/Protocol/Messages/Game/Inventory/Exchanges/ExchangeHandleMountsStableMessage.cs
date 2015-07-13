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
    
    
    public class ExchangeHandleMountsStableMessage : NetworkMessage
    {
        
        public const int Id = 6562;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private byte m_actionType;
        
        public virtual byte ActionType
        {
            get
            {
                return m_actionType;
            }
            set
            {
                m_actionType = value;
            }
        }
        
        private List<System.UInt32> m_ridesId;
        
        public virtual List<System.UInt32> RidesId
        {
            get
            {
                return m_ridesId;
            }
            set
            {
                m_ridesId = value;
            }
        }
        
        public void Initiate(byte actionType, List<System.UInt32> ridesId)
        {
            m_actionType = actionType;
            m_ridesId = ridesId;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteByte(m_actionType);
            writer.WriteShort(((short)(m_ridesId.Count)));
            int ridesIdIndex;
            for (ridesIdIndex = 0; (ridesIdIndex < m_ridesId.Count); ridesIdIndex = (ridesIdIndex + 1))
            {
                writer.WriteVarUhInt(m_ridesId[ridesIdIndex]);
            }
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_actionType = reader.ReadByte();
            int ridesIdCount = reader.ReadUShort();
            int ridesIdIndex;
            m_ridesId = new System.Collections.Generic.List<uint>();
            for (ridesIdIndex = 0; (ridesIdIndex < ridesIdCount); ridesIdIndex = (ridesIdIndex + 1))
            {
                m_ridesId.Add(reader.ReadVarUhInt());
            }
        }
    }
}
