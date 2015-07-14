//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Protocol.Messages.Connection.Search
{
    using System.Collections.Generic;
    using System;
    using Protocol.IO.BigEndian;
    
    
    public class AcquaintanceSearchErrorMessage : AbstractAbstractNetworkMessage
    {
        
        public const int Id = 6143;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private byte m_reason;
        
        public virtual byte Reason
        {
            get
            {
                return m_reason;
            }
            set
            {
                m_reason = value;
            }
        }
        
        public void Initiate(byte reason)
        {
            m_reason = reason;
        }
        
        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteByte(m_reason);
        }
        
        public override void Deserialize(BigEndianReader reader)
        {
            m_reason = reader.ReadByte();
        }
    }
}
