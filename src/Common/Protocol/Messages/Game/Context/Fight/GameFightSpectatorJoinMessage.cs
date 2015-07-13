//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Context.Fight
{
    using Common.Protocol.Network.Types.Game.Context.Roleplay.Party;
    using System.Collections.Generic;
    using System;
    
    
    public class GameFightSpectatorJoinMessage : GameFightJoinMessage
    {
        
        public const int Id = 6504;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private List<NamedPartyTeam> m_namedPartyTeams;
        
        public virtual List<NamedPartyTeam> NamedPartyTeams
        {
            get
            {
                return m_namedPartyTeams;
            }
            set
            {
                m_namedPartyTeams = value;
            }
        }
        
        public void Initiate(List<NamedPartyTeam> namedPartyTeams)
        {
            m_namedPartyTeams = namedPartyTeams;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(((short)(m_namedPartyTeams.Count)));
            int namedPartyTeamsIndex;
            for (namedPartyTeamsIndex = 0; (namedPartyTeamsIndex < m_namedPartyTeams.Count); namedPartyTeamsIndex = (namedPartyTeamsIndex + 1))
            {
                NamedPartyTeam objectToSend = m_namedPartyTeams[namedPartyTeamsIndex];
                objectToSend.Serialize(writer);
            }
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            int namedPartyTeamsCount = reader.ReadUShort();
            int namedPartyTeamsIndex;
            m_namedPartyTeams = new System.Collections.Generic.List<NamedPartyTeam>();
            for (namedPartyTeamsIndex = 0; (namedPartyTeamsIndex < namedPartyTeamsCount); namedPartyTeamsIndex = (namedPartyTeamsIndex + 1))
            {
                NamedPartyTeam objectToAdd = new NamedPartyTeam();
                objectToAdd.Deserialize(reader);
                m_namedPartyTeams.Add(objectToAdd);
            }
        }
    }
}
