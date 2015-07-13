//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Guild
{
    using System.Collections.Generic;
    using System;
    
    
    public class GuildModificationStartedMessage : NetworkMessage
    {
        
        public const int Id = 6324;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private bool m_canChangeName;
        
        public virtual bool CanChangeName
        {
            get
            {
                return m_canChangeName;
            }
            set
            {
                m_canChangeName = value;
            }
        }
        
        private bool m_canChangeEmblem;
        
        public virtual bool CanChangeEmblem
        {
            get
            {
                return m_canChangeEmblem;
            }
            set
            {
                m_canChangeEmblem = value;
            }
        }
        
        public void Initiate(bool canChangeName, bool canChangeEmblem)
        {
            m_canChangeName = canChangeName;
            m_canChangeEmblem = canChangeEmblem;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            byte flag = new byte();
            BooleanByteWrapper.SetFlag(0, flag, m_canChangeName);
            BooleanByteWrapper.SetFlag(1, flag, m_canChangeEmblem);
            writer.WriteByte(flag);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            byte flag = reader.ReadByte();
            m_canChangeName = BooleanByteWrapper.GetFlag(flag, 0);
            m_canChangeEmblem = BooleanByteWrapper.GetFlag(flag, 1);
        }
    }
}
