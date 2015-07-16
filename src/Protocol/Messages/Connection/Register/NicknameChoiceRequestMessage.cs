//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Protocol.Messages.Connection.Register
{
    using System.Collections.Generic;
    using System;
    using Protocol.IO.BigEndian;
    
    
    public class NicknameChoiceRequestMessage : AbstractNetworkMessage
    {
        
        public const int Id = 5639;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private string m_nickname;
        
        public virtual string Nickname
        {
            get
            {
                return m_nickname;
            }
            set
            {
                m_nickname = value;
            }
        }
        
        public void Initiate(string nickname)
        {
            m_nickname = nickname;
        }
        
        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUTF(m_nickname);
        }
        
        public override void Deserialize(BigEndianReader reader)
        {
            m_nickname = reader.ReadUTF();
        }
    }
}
