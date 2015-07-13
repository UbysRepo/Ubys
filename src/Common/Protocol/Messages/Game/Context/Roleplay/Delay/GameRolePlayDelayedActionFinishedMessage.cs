//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Context.Roleplay.Delay
{
    using System.Collections.Generic;
    using System;
    
    
    public class GameRolePlayDelayedActionFinishedMessage : NetworkMessage
    {
        
        public const int Id = 6150;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private int m_delayedCharacterId;
        
        public virtual int DelayedCharacterId
        {
            get
            {
                return m_delayedCharacterId;
            }
            set
            {
                m_delayedCharacterId = value;
            }
        }
        
        private byte m_delayTypeId;
        
        public virtual byte DelayTypeId
        {
            get
            {
                return m_delayTypeId;
            }
            set
            {
                m_delayTypeId = value;
            }
        }
        
        public void Initiate(int delayedCharacterId, byte delayTypeId)
        {
            m_delayedCharacterId = delayedCharacterId;
            m_delayTypeId = delayTypeId;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteInt(m_delayedCharacterId);
            writer.WriteByte(m_delayTypeId);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_delayedCharacterId = reader.ReadInt();
            m_delayTypeId = reader.ReadByte();
        }
    }
}
