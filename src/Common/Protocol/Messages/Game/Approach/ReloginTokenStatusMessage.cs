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
    
    
    public class ReloginTokenStatusMessage : NetworkMessage
    {
        
        public const int Id = 6539;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private bool m_validToken;
        
        public virtual bool ValidToken
        {
            get
            {
                return m_validToken;
            }
            set
            {
                m_validToken = value;
            }
        }
        
        private string m_token;
        
        public virtual string Token
        {
            get
            {
                return m_token;
            }
            set
            {
                m_token = value;
            }
        }
        
        public void Initiate(bool validToken, string token)
        {
            m_validToken = validToken;
            m_token = token;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteBoolean(m_validToken);
            writer.WriteUTF(m_token);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_validToken = reader.ReadBoolean();
            m_token = reader.ReadUTF();
        }
    }
}
