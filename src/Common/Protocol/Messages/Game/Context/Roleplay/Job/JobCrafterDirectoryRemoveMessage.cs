//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Context.Roleplay.Job
{
    using System.Collections.Generic;
    using System;
    
    
    public class JobCrafterDirectoryRemoveMessage : NetworkMessage
    {
        
        public const int Id = 5653;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private byte m_jobId;
        
        public virtual byte JobId
        {
            get
            {
                return m_jobId;
            }
            set
            {
                m_jobId = value;
            }
        }
        
        private uint m_playerId;
        
        public virtual uint PlayerId
        {
            get
            {
                return m_playerId;
            }
            set
            {
                m_playerId = value;
            }
        }
        
        public void Initiate(byte jobId, uint playerId)
        {
            m_jobId = jobId;
            m_playerId = playerId;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteByte(m_jobId);
            writer.WriteVarUhInt(m_playerId);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_jobId = reader.ReadByte();
            m_playerId = reader.ReadVarUhInt();
        }
    }
}
