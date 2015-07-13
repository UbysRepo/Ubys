//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Types.Game.Context.Roleplay.Party
{
    using Common.Protocol.Network.Types.Game.Character.Choice;
    using Common.Protocol.Network.Types.Game.Context.Roleplay.Party.Companion;
    using Common.Protocol.Network.Types.Game.Look;
    using System.Collections.Generic;
    using System;
    
    
    public class PartyInvitationMemberInformations : CharacterBaseInformations
    {
        
        public const int Id = 376;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
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
        
        private List<PartyCompanionBaseInformations> m_companions;
        
        public virtual List<PartyCompanionBaseInformations> Companions
        {
            get
            {
                return m_companions;
            }
            set
            {
                m_companions = value;
            }
        }
        
        public void Initiate(short worldX, short worldY, int mapId, ushort subAreaId, List<PartyCompanionBaseInformations> companions)
        {
            m_worldX = worldX;
            m_worldY = worldY;
            m_mapId = mapId;
            m_subAreaId = subAreaId;
            m_companions = companions;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(m_worldX);
            writer.WriteShort(m_worldY);
            writer.WriteInt(m_mapId);
            writer.WriteVarUhShort(m_subAreaId);
            writer.WriteShort(((short)(m_companions.Count)));
            int companionsIndex;
            for (companionsIndex = 0; (companionsIndex < m_companions.Count); companionsIndex = (companionsIndex + 1))
            {
                PartyCompanionBaseInformations objectToSend = m_companions[companionsIndex];
                objectToSend.Serialize(writer);
            }
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            m_worldX = reader.ReadShort();
            m_worldY = reader.ReadShort();
            m_mapId = reader.ReadInt();
            m_subAreaId = reader.ReadVarUhShort();
            int companionsCount = reader.ReadUShort();
            int companionsIndex;
            m_companions = new System.Collections.Generic.List<PartyCompanionBaseInformations>();
            for (companionsIndex = 0; (companionsIndex < companionsCount); companionsIndex = (companionsIndex + 1))
            {
                PartyCompanionBaseInformations objectToAdd = new PartyCompanionBaseInformations();
                objectToAdd.Deserialize(reader);
                m_companions.Add(objectToAdd);
            }
        }
    }
}
