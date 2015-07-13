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
    using Common.Protocol.Network.Types.Game.Social;
    using Common.Protocol.Network.Types.Game.Character;
    using Common.Protocol.Network;
    using System.Collections.Generic;
    using System;
    
    
    public class GuildFactsMessage : NetworkMessage
    {
        
        public const int Id = 6415;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private GuildFactSheetInformations m_infos;
        
        public virtual GuildFactSheetInformations Infos
        {
            get
            {
                return m_infos;
            }
            set
            {
                m_infos = value;
            }
        }
        
        private int m_creationDate;
        
        public virtual int CreationDate
        {
            get
            {
                return m_creationDate;
            }
            set
            {
                m_creationDate = value;
            }
        }
        
        private ushort m_nbTaxCollectors;
        
        public virtual ushort NbTaxCollectors
        {
            get
            {
                return m_nbTaxCollectors;
            }
            set
            {
                m_nbTaxCollectors = value;
            }
        }
        
        private bool m_enabled;
        
        public virtual bool Enabled
        {
            get
            {
                return m_enabled;
            }
            set
            {
                m_enabled = value;
            }
        }
        
        private List<CharacterMinimalInformations> m_members;
        
        public virtual List<CharacterMinimalInformations> Members
        {
            get
            {
                return m_members;
            }
            set
            {
                m_members = value;
            }
        }
        
        public void Initiate(GuildFactSheetInformations infos, int creationDate, ushort nbTaxCollectors, bool enabled, List<CharacterMinimalInformations> members)
        {
            m_infos = infos;
            m_creationDate = creationDate;
            m_nbTaxCollectors = nbTaxCollectors;
            m_enabled = enabled;
            m_members = members;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteUShort(((ushort)(m_infos.ProtocolId)));
            m_infos.Serialize(writer);
            writer.WriteInt(m_creationDate);
            writer.WriteVarUhShort(m_nbTaxCollectors);
            writer.WriteBoolean(m_enabled);
            writer.WriteShort(((short)(m_members.Count)));
            int membersIndex;
            for (membersIndex = 0; (membersIndex < m_members.Count); membersIndex = (membersIndex + 1))
            {
                CharacterMinimalInformations objectToSend = m_members[membersIndex];
                objectToSend.Serialize(writer);
            }
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_infos = ProtocolManager.GetTypeInstance<GuildFactSheetInformations>(reader.ReadUShort());
            m_infos.Deserialize(reader);
            m_creationDate = reader.ReadInt();
            m_nbTaxCollectors = reader.ReadVarUhShort();
            m_enabled = reader.ReadBoolean();
            int membersCount = reader.ReadUShort();
            int membersIndex;
            m_members = new System.Collections.Generic.List<CharacterMinimalInformations>();
            for (membersIndex = 0; (membersIndex < membersCount); membersIndex = (membersIndex + 1))
            {
                CharacterMinimalInformations objectToAdd = new CharacterMinimalInformations();
                objectToAdd.Deserialize(reader);
                m_members.Add(objectToAdd);
            }
        }
    }
}
