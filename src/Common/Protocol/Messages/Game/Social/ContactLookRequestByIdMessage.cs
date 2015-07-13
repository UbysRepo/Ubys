//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Social
{
    using System.Collections.Generic;
    using System;
    
    
    public class ContactLookRequestByIdMessage : ContactLookRequestMessage
    {
        
        public const int Id = 5935;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
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
        
        public void Initiate(uint playerId)
        {
            m_playerId = playerId;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(m_playerId);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            m_playerId = reader.ReadVarUhInt();
        }
    }
}
