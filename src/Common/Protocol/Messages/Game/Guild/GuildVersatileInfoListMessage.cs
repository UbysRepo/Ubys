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
    using Common.Protocol.Network;
    using System.Collections.Generic;
    using System;
    
    
    public class GuildVersatileInfoListMessage : NetworkMessage
    {
        
        public const int Id = 6435;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private List<GuildVersatileInformations> m_guilds;
        
        public virtual List<GuildVersatileInformations> Guilds
        {
            get
            {
                return m_guilds;
            }
            set
            {
                m_guilds = value;
            }
        }
        
        public void Initiate(List<GuildVersatileInformations> guilds)
        {
            m_guilds = guilds;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteShort(((short)(m_guilds.Count)));
            int guildsIndex;
            for (guildsIndex = 0; (guildsIndex < m_guilds.Count); guildsIndex = (guildsIndex + 1))
            {
                GuildVersatileInformations objectToSend = m_guilds[guildsIndex];
                writer.WriteUShort(((ushort)(objectToSend.ProtocolId)));
                objectToSend.Serialize(writer);
            }
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            int guildsCount = reader.ReadUShort();
            int guildsIndex;
            m_guilds = new System.Collections.Generic.List<GuildVersatileInformations>();
            for (guildsIndex = 0; (guildsIndex < guildsCount); guildsIndex = (guildsIndex + 1))
            {
                GuildVersatileInformations objectToAdd = ProtocolManager.GetTypeInstance<GuildVersatileInformations>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                m_guilds.Add(objectToAdd);
            }
        }
    }
}
