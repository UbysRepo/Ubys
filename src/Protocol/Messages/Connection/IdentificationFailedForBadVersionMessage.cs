//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Protocol.Messages.Connection
{
    using System.Collections.Generic;
    using System;
    using Protocol.IO.BigEndian;
    
    
    public class IdentificationFailedForBadVersionMessage : IdentificationFailedMessage
    {
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private Protocol.Types.Version.Version m_requiredVersion;

        public virtual Protocol.Types.Version.Version RequiredVersion
        {
            get
            {
                return m_requiredVersion;
            }
            set
            {
                m_requiredVersion = value;
            }
        }

        public void Initiate(Protocol.Types.Version.Version requiredVersion)
        {
            m_requiredVersion = requiredVersion;
        }
        
        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            m_requiredVersion.Serialize(writer);
        }
        
        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            m_requiredVersion = new Protocol.Types.Version.Version();
            m_requiredVersion.Deserialize(reader);
        }
    }
}
