//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Atlas.Compass
{
    using Common.Protocol.Network.Types.Game.Context;
    using System.Collections.Generic;
    using System;
    
    
    public class CompassUpdatePartyMemberMessage : CompassUpdateMessage
    {
        
        public const int Id = 5589;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private uint m_memberId;
        
        public virtual uint MemberId
        {
            get
            {
                return m_memberId;
            }
            set
            {
                m_memberId = value;
            }
        }
        
        public void Initiate(uint memberId)
        {
            m_memberId = memberId;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(m_memberId);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            m_memberId = reader.ReadVarUhInt();
        }
    }
}
