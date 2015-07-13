//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Context.Mount
{
    using System.Collections.Generic;
    using System;
    
    
    public class MountXpRatioMessage : NetworkMessage
    {
        
        public const int Id = 5970;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private byte m_ratio;
        
        public virtual byte Ratio
        {
            get
            {
                return m_ratio;
            }
            set
            {
                m_ratio = value;
            }
        }
        
        public void Initiate(byte ratio)
        {
            m_ratio = ratio;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteByte(m_ratio);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_ratio = reader.ReadByte();
        }
    }
}
