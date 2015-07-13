//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Chat
{
    using System.Collections.Generic;
    using System;
    
    
    public class ChatAbstractServerMessage : NetworkMessage
    {
        
        public const int Id = 880;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private byte m_channel;
        
        public virtual byte Channel
        {
            get
            {
                return m_channel;
            }
            set
            {
                m_channel = value;
            }
        }
        
        private string m_content;
        
        public virtual string Content
        {
            get
            {
                return m_content;
            }
            set
            {
                m_content = value;
            }
        }
        
        private int m_timestamp;
        
        public virtual int Timestamp
        {
            get
            {
                return m_timestamp;
            }
            set
            {
                m_timestamp = value;
            }
        }
        
        private string m_fingerprint;
        
        public virtual string Fingerprint
        {
            get
            {
                return m_fingerprint;
            }
            set
            {
                m_fingerprint = value;
            }
        }
        
        public void Initiate(byte channel, string content, int timestamp, string fingerprint)
        {
            m_channel = channel;
            m_content = content;
            m_timestamp = timestamp;
            m_fingerprint = fingerprint;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteByte(m_channel);
            writer.WriteUTF(m_content);
            writer.WriteInt(m_timestamp);
            writer.WriteUTF(m_fingerprint);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_channel = reader.ReadByte();
            m_content = reader.ReadUTF();
            m_timestamp = reader.ReadInt();
            m_fingerprint = reader.ReadUTF();
        }
    }
}
