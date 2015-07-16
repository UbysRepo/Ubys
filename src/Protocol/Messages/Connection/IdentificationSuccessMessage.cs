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
    
    
    public class IdentificationSuccessMessage : AbstractNetworkMessage
    {
        
        public const int Id = 22;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private bool m_hasRights;
        
        public virtual bool HasRights
        {
            get
            {
                return m_hasRights;
            }
            set
            {
                m_hasRights = value;
            }
        }
        
        private bool m_wasAlreadyConnected;
        
        public virtual bool WasAlreadyConnected
        {
            get
            {
                return m_wasAlreadyConnected;
            }
            set
            {
                m_wasAlreadyConnected = value;
            }
        }
        
        private string m_login;
        
        public virtual string Login
        {
            get
            {
                return m_login;
            }
            set
            {
                m_login = value;
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
        
        private int m_accountId;
        
        public virtual int AccountId
        {
            get
            {
                return m_accountId;
            }
            set
            {
                m_accountId = value;
            }
        }
        
        private byte m_communityId;
        
        public virtual byte CommunityId
        {
            get
            {
                return m_communityId;
            }
            set
            {
                m_communityId = value;
            }
        }
        
        private string m_secretQuestion;
        
        public virtual string SecretQuestion
        {
            get
            {
                return m_secretQuestion;
            }
            set
            {
                m_secretQuestion = value;
            }
        }
        
        private double m_accountCreation;
        
        public virtual double AccountCreation
        {
            get
            {
                return m_accountCreation;
            }
            set
            {
                m_accountCreation = value;
            }
        }
        
        private double m_subscriptionElapsedDuration;
        
        public virtual double SubscriptionElapsedDuration
        {
            get
            {
                return m_subscriptionElapsedDuration;
            }
            set
            {
                m_subscriptionElapsedDuration = value;
            }
        }
        
        private double m_subscriptionEndDate;
        
        public virtual double SubscriptionEndDate
        {
            get
            {
                return m_subscriptionEndDate;
            }
            set
            {
                m_subscriptionEndDate = value;
            }
        }
        
        public void Initiate(bool hasRights, bool wasAlreadyConnected, string login, string nickname, int accountId, byte communityId, string secretQuestion, double accountCreation, double subscriptionElapsedDuration, double subscriptionEndDate)
        {
            m_hasRights = hasRights;
            m_wasAlreadyConnected = wasAlreadyConnected;
            m_login = login;
            m_nickname = nickname;
            m_accountId = accountId;
            m_communityId = communityId;
            m_secretQuestion = secretQuestion;
            m_accountCreation = accountCreation;
            m_subscriptionElapsedDuration = subscriptionElapsedDuration;
            m_subscriptionEndDate = subscriptionEndDate;
        }
        
        public override void Serialize(BigEndianWriter writer)
        {
            byte flag = new byte();
            BooleanByteWrapper.SetFlag(0, flag, m_hasRights);
            BooleanByteWrapper.SetFlag(1, flag, m_wasAlreadyConnected);
            writer.WriteByte(flag);
            writer.WriteUTF(m_login);
            writer.WriteUTF(m_nickname);
            writer.WriteInt(m_accountId);
            writer.WriteByte(m_communityId);
            writer.WriteUTF(m_secretQuestion);
            writer.WriteDouble(m_accountCreation);
            writer.WriteDouble(m_subscriptionElapsedDuration);
            writer.WriteDouble(m_subscriptionEndDate);
        }
        
        public override void Deserialize(BigEndianReader reader)
        {
            byte flag = reader.ReadByte();
            m_hasRights = BooleanByteWrapper.GetFlag(flag, 0);
            m_wasAlreadyConnected = BooleanByteWrapper.GetFlag(flag, 1);
            m_login = reader.ReadUTF();
            m_nickname = reader.ReadUTF();
            m_accountId = reader.ReadInt();
            m_communityId = reader.ReadByte();
            m_secretQuestion = reader.ReadUTF();
            m_accountCreation = reader.ReadDouble();
            m_subscriptionElapsedDuration = reader.ReadDouble();
            m_subscriptionEndDate = reader.ReadDouble();
        }
    }
}
