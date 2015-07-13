//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Actions
{
    using System.Collections.Generic;
    using System;
    
    
    public class AbstractGameActionWithAckMessage : AbstractGameActionMessage
    {
        
        public const int Id = 1001;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private short m_waitAckId;
        
        public virtual short WaitAckId
        {
            get
            {
                return m_waitAckId;
            }
            set
            {
                m_waitAckId = value;
            }
        }
        
        public void Initiate(short waitAckId)
        {
            m_waitAckId = waitAckId;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(m_waitAckId);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            m_waitAckId = reader.ReadShort();
        }
    }
}
