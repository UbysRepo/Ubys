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
    
    
    public class IdentificationSuccessWithLoginTokenMessage : IdentificationSuccessMessage
    {
        
        public const int Id = 6209;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private string m_loginToken;
        
        public virtual string LoginToken
        {
            get
            {
                return m_loginToken;
            }
            set
            {
                m_loginToken = value;
            }
        }
        
        public void Initiate(string loginToken)
        {
            m_loginToken = loginToken;
        }
        
        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(m_loginToken);
        }
        
        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            m_loginToken = reader.ReadUTF();
        }
    }
}