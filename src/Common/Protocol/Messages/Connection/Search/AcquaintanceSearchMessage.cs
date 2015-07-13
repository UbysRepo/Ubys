//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Connection.Search
{
    using System.Collections.Generic;
    using System;
    
    
    public class AcquaintanceSearchMessage : NetworkMessage
    {
        
        public const int Id = 6144;
        
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
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteUTF(m_nickname);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_nickname = reader.ReadUTF();
        }
    }
}
