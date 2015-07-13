//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Tinsel
{
    using System.Collections.Generic;
    using System;
    
    
    public class OrnamentSelectErrorMessage : NetworkMessage
    {
        
        public const int Id = 6370;
        
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
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteByte(m_reason);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_reason = reader.ReadByte();
        }
    }
}
