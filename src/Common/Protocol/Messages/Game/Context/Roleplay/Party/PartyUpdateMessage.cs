//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Common.Protocol.Network.Types.Game.Context.Roleplay.Party;
    using Common.Protocol.Network;
    using System.Collections.Generic;
    using System;
    
    
    public class PartyUpdateMessage : AbstractPartyEventMessage
    {
        
        public const int Id = 5575;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private PartyMemberInformations m_memberInformations;
        
        public virtual PartyMemberInformations MemberInformations
        {
            get
            {
                return m_memberInformations;
            }
            set
            {
                m_memberInformations = value;
            }
        }
        
        public void Initiate(PartyMemberInformations memberInformations)
        {
            m_memberInformations = memberInformations;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort(((ushort)(m_memberInformations.ProtocolId)));
            m_memberInformations.Serialize(writer);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            m_memberInformations = ProtocolManager.GetTypeInstance<PartyMemberInformations>(reader.ReadUShort());
            m_memberInformations.Deserialize(reader);
        }
    }
}
