//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Actions.Fight
{
    using Common.Protocol.Network.Messages.Game.Actions;
    using System.Collections.Generic;
    using System;
    
    
    public class GameActionFightDispellMessage : AbstractGameActionMessage
    {
        
        public const int Id = 5533;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private int m_targetId;
        
        public virtual int TargetId
        {
            get
            {
                return m_targetId;
            }
            set
            {
                m_targetId = value;
            }
        }
        
        public void Initiate(int targetId)
        {
            m_targetId = targetId;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(m_targetId);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            m_targetId = reader.ReadInt();
        }
    }
}
