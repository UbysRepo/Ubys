//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Pvp
{
    using System.Collections.Generic;
    using System;
    
    
    public class SetEnableAVARequestMessage : NetworkMessage
    {
        
        public const int Id = 6443;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private bool m_enable;
        
        public virtual bool Enable
        {
            get
            {
                return m_enable;
            }
            set
            {
                m_enable = value;
            }
        }
        
        public void Initiate(bool enable)
        {
            m_enable = enable;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteBoolean(m_enable);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_enable = reader.ReadBoolean();
        }
    }
}
