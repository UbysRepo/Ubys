//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Approach
{
    using System.Collections.Generic;
    using System;
    
    
    public class AuthenticationTicketMessage : NetworkMessage
    {
        
        public const int Id = 110;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private string m_lang;
        
        public virtual string Lang
        {
            get
            {
                return m_lang;
            }
            set
            {
                m_lang = value;
            }
        }
        
        private string m_ticket;
        
        public virtual string Ticket
        {
            get
            {
                return m_ticket;
            }
            set
            {
                m_ticket = value;
            }
        }
        
        public void Initiate(string lang, string ticket)
        {
            m_lang = lang;
            m_ticket = ticket;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteUTF(m_lang);
            writer.WriteUTF(m_ticket);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_lang = reader.ReadUTF();
            m_ticket = reader.ReadUTF();
        }
    }
}
