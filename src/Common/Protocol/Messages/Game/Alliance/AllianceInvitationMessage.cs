//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Alliance
{
    using System.Collections.Generic;
    using System;
    
    
    public class AllianceInvitationMessage : NetworkMessage
    {
        
        public const int Id = 6395;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private uint m_targetId;
        
        public virtual uint TargetId
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
        
        public void Initiate(uint targetId)
        {
            m_targetId = targetId;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarUhInt(m_targetId);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_targetId = reader.ReadVarUhInt();
        }
    }
}
