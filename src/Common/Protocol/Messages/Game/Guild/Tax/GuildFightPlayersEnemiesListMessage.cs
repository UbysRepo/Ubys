//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Guild.Tax
{
    using Common.Protocol.Network.Types.Game.Character;
    using System.Collections.Generic;
    using System;
    
    
    public class GuildFightPlayersEnemiesListMessage : NetworkMessage
    {
        
        public const int Id = 5928;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private int m_fightId;
        
        public virtual int FightId
        {
            get
            {
                return m_fightId;
            }
            set
            {
                m_fightId = value;
            }
        }
        
        private List<CharacterMinimalPlusLookInformations> m_playerInfo;
        
        public virtual List<CharacterMinimalPlusLookInformations> PlayerInfo
        {
            get
            {
                return m_playerInfo;
            }
            set
            {
                m_playerInfo = value;
            }
        }
        
        public void Initiate(int fightId, List<CharacterMinimalPlusLookInformations> playerInfo)
        {
            m_fightId = fightId;
            m_playerInfo = playerInfo;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteInt(m_fightId);
            writer.WriteShort(((short)(m_playerInfo.Count)));
            int playerInfoIndex;
            for (playerInfoIndex = 0; (playerInfoIndex < m_playerInfo.Count); playerInfoIndex = (playerInfoIndex + 1))
            {
                CharacterMinimalPlusLookInformations objectToSend = m_playerInfo[playerInfoIndex];
                objectToSend.Serialize(writer);
            }
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_fightId = reader.ReadInt();
            int playerInfoCount = reader.ReadUShort();
            int playerInfoIndex;
            m_playerInfo = new System.Collections.Generic.List<CharacterMinimalPlusLookInformations>();
            for (playerInfoIndex = 0; (playerInfoIndex < playerInfoCount); playerInfoIndex = (playerInfoIndex + 1))
            {
                CharacterMinimalPlusLookInformations objectToAdd = new CharacterMinimalPlusLookInformations();
                objectToAdd.Deserialize(reader);
                m_playerInfo.Add(objectToAdd);
            }
        }
    }
}
