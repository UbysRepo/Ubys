//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Report
{
    using System.Collections.Generic;
    using System;
    
    
    public class CharacterReportMessage : NetworkMessage
    {
        
        public const int Id = 6079;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private uint m_reportedId;
        
        public virtual uint ReportedId
        {
            get
            {
                return m_reportedId;
            }
            set
            {
                m_reportedId = value;
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
        
        public void Initiate(uint reportedId, byte reason)
        {
            m_reportedId = reportedId;
            m_reason = reason;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarUhInt(m_reportedId);
            writer.WriteByte(m_reason);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_reportedId = reader.ReadVarUhInt();
            m_reason = reader.ReadByte();
        }
    }
}
