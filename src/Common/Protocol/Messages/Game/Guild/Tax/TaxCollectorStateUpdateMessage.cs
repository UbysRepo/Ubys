//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Guild.Tax
{
    using System.Collections.Generic;
    using System;
    
    
    public class TaxCollectorStateUpdateMessage : NetworkMessage
    {
        
        public const int Id = 6455;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private int m_uniqueId;
        
        public virtual int UniqueId
        {
            get
            {
                return m_uniqueId;
            }
            set
            {
                m_uniqueId = value;
            }
        }
        
        private byte m_state;
        
        public virtual byte State
        {
            get
            {
                return m_state;
            }
            set
            {
                m_state = value;
            }
        }
        
        public void Initiate(int uniqueId, byte state)
        {
            m_uniqueId = uniqueId;
            m_state = state;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteInt(m_uniqueId);
            writer.WriteByte(m_state);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_uniqueId = reader.ReadInt();
            m_state = reader.ReadByte();
        }
    }
}
