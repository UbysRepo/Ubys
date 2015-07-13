//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Context.Roleplay.Npc
{
    using System.Collections.Generic;
    using System;
    
    
    public class NpcDialogCreationMessage : NetworkMessage
    {
        
        public const int Id = 5618;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
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
        
        private int m_npcId;
        
        public virtual int NpcId
        {
            get
            {
                return m_npcId;
            }
            set
            {
                m_npcId = value;
            }
        }
        
        public void Initiate(int mapId, int npcId)
        {
            m_mapId = mapId;
            m_npcId = npcId;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteInt(m_mapId);
            writer.WriteInt(m_npcId);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_mapId = reader.ReadInt();
            m_npcId = reader.ReadInt();
        }
    }
}
