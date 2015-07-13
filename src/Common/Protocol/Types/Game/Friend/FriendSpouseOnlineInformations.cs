//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Types.Game.Friend
{
    using Common.Protocol.Network.Types.Game.Look;
    using Common.Protocol.Network.Types.Game.Context.Roleplay;
    using System.Collections.Generic;
    using System;
    
    
    public class FriendSpouseOnlineInformations : FriendSpouseInformations
    {
        
        public const int Id = 93;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private bool m_inFight;
        
        public virtual bool InFight
        {
            get
            {
                return m_inFight;
            }
            set
            {
                m_inFight = value;
            }
        }
        
        private bool m_followSpouse;
        
        public virtual bool FollowSpouse
        {
            get
            {
                return m_followSpouse;
            }
            set
            {
                m_followSpouse = value;
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
        
        public void Initiate(bool inFight, bool followSpouse, int mapId, ushort subAreaId)
        {
            m_inFight = inFight;
            m_followSpouse = followSpouse;
            m_mapId = mapId;
            m_subAreaId = subAreaId;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            byte flag = new byte();
            BooleanByteWrapper.SetFlag(0, flag, m_inFight);
            BooleanByteWrapper.SetFlag(1, flag, m_followSpouse);
            writer.WriteByte(flag);
            writer.WriteInt(m_mapId);
            writer.WriteVarUhShort(m_subAreaId);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            byte flag = reader.ReadByte();
            m_inFight = BooleanByteWrapper.GetFlag(flag, 0);
            m_followSpouse = BooleanByteWrapper.GetFlag(flag, 1);
            m_mapId = reader.ReadInt();
            m_subAreaId = reader.ReadVarUhShort();
        }
    }
}
