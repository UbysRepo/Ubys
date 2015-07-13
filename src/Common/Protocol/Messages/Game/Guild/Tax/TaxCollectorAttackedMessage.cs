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
    using Common.Protocol.Network.Types.Game.Context.Roleplay;
    using System.Collections.Generic;
    using System;
    
    
    public class TaxCollectorAttackedMessage : NetworkMessage
    {
        
        public const int Id = 5918;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private ushort m_firstNameId;
        
        public virtual ushort FirstNameId
        {
            get
            {
                return m_firstNameId;
            }
            set
            {
                m_firstNameId = value;
            }
        }
        
        private ushort m_lastNameId;
        
        public virtual ushort LastNameId
        {
            get
            {
                return m_lastNameId;
            }
            set
            {
                m_lastNameId = value;
            }
        }
        
        private short m_worldX;
        
        public virtual short WorldX
        {
            get
            {
                return m_worldX;
            }
            set
            {
                m_worldX = value;
            }
        }
        
        private short m_worldY;
        
        public virtual short WorldY
        {
            get
            {
                return m_worldY;
            }
            set
            {
                m_worldY = value;
            }
        }
        
        private int m_mapId;
        
        public virtual int MapId
        {
            get
            {
                return m_mapId;
            }
            set
            {
                m_mapId = value;
            }
        }
        
        private ushort m_subAreaId;
        
        public virtual ushort SubAreaId
        {
            get
            {
                return m_subAreaId;
            }
            set
            {
                m_subAreaId = value;
            }
        }
        
        private BasicGuildInformations m_guild;
        
        public virtual BasicGuildInformations Guild
        {
            get
            {
                return m_guild;
            }
            set
            {
                m_guild = value;
            }
        }
        
        public void Initiate(ushort firstNameId, ushort lastNameId, short worldX, short worldY, int mapId, ushort subAreaId, BasicGuildInformations guild)
        {
            m_firstNameId = firstNameId;
            m_lastNameId = lastNameId;
            m_worldX = worldX;
            m_worldY = worldY;
            m_mapId = mapId;
            m_subAreaId = subAreaId;
            m_guild = guild;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarUhShort(m_firstNameId);
            writer.WriteVarUhShort(m_lastNameId);
            writer.WriteShort(m_worldX);
            writer.WriteShort(m_worldY);
            writer.WriteInt(m_mapId);
            writer.WriteVarUhShort(m_subAreaId);
            m_guild.Serialize(writer);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_firstNameId = reader.ReadVarUhShort();
            m_lastNameId = reader.ReadVarUhShort();
            m_worldX = reader.ReadShort();
            m_worldY = reader.ReadShort();
            m_mapId = reader.ReadInt();
            m_subAreaId = reader.ReadVarUhShort();
            m_guild = new BasicGuildInformations();
            m_guild.Deserialize(reader);
        }
    }
}
