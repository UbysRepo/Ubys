//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Types.Game.House
{
    using System.Collections.Generic;
    using System;
    
    
    public class HouseInformationsForSell : NetworkType
    {
        
        public const int Id = 221;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private uint m_modelId;
        
        public virtual uint ModelId
        {
            get
            {
                return m_modelId;
            }
            set
            {
                m_modelId = value;
            }
        }
        
        private string m_ownerName;
        
        public virtual string OwnerName
        {
            get
            {
                return m_ownerName;
            }
            set
            {
                m_ownerName = value;
            }
        }
        
        private bool m_ownerConnected;
        
        public virtual bool OwnerConnected
        {
            get
            {
                return m_ownerConnected;
            }
            set
            {
                m_ownerConnected = value;
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
        
        private byte m_nbRoom;
        
        public virtual byte NbRoom
        {
            get
            {
                return m_nbRoom;
            }
            set
            {
                m_nbRoom = value;
            }
        }
        
        private byte m_nbChest;
        
        public virtual byte NbChest
        {
            get
            {
                return m_nbChest;
            }
            set
            {
                m_nbChest = value;
            }
        }
        
        private List<System.Int32> m_skillListIds;
        
        public virtual List<System.Int32> SkillListIds
        {
            get
            {
                return m_skillListIds;
            }
            set
            {
                m_skillListIds = value;
            }
        }
        
        private bool m_isLocked;
        
        public virtual bool IsLocked
        {
            get
            {
                return m_isLocked;
            }
            set
            {
                m_isLocked = value;
            }
        }
        
        private uint m_price;
        
        public virtual uint Price
        {
            get
            {
                return m_price;
            }
            set
            {
                m_price = value;
            }
        }
        
        public void Initiate(uint modelId, string ownerName, bool ownerConnected, short worldX, short worldY, ushort subAreaId, byte nbRoom, byte nbChest, List<System.Int32> skillListIds, bool isLocked, uint price)
        {
            m_modelId = modelId;
            m_ownerName = ownerName;
            m_ownerConnected = ownerConnected;
            m_worldX = worldX;
            m_worldY = worldY;
            m_subAreaId = subAreaId;
            m_nbRoom = nbRoom;
            m_nbChest = nbChest;
            m_skillListIds = skillListIds;
            m_isLocked = isLocked;
            m_price = price;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarUhInt(m_modelId);
            writer.WriteUTF(m_ownerName);
            writer.WriteBoolean(m_ownerConnected);
            writer.WriteShort(m_worldX);
            writer.WriteShort(m_worldY);
            writer.WriteVarUhShort(m_subAreaId);
            writer.WriteByte(m_nbRoom);
            writer.WriteByte(m_nbChest);
            writer.WriteShort(((short)(m_skillListIds.Count)));
            int skillListIdsIndex;
            for (skillListIdsIndex = 0; (skillListIdsIndex < m_skillListIds.Count); skillListIdsIndex = (skillListIdsIndex + 1))
            {
                writer.WriteInt(m_skillListIds[skillListIdsIndex]);
            }
            writer.WriteBoolean(m_isLocked);
            writer.WriteVarUhInt(m_price);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_modelId = reader.ReadVarUhInt();
            m_ownerName = reader.ReadUTF();
            m_ownerConnected = reader.ReadBoolean();
            m_worldX = reader.ReadShort();
            m_worldY = reader.ReadShort();
            m_subAreaId = reader.ReadVarUhShort();
            m_nbRoom = reader.ReadByte();
            m_nbChest = reader.ReadByte();
            int skillListIdsCount = reader.ReadUShort();
            int skillListIdsIndex;
            m_skillListIds = new System.Collections.Generic.List<int>();
            for (skillListIdsIndex = 0; (skillListIdsIndex < skillListIdsCount); skillListIdsIndex = (skillListIdsIndex + 1))
            {
                m_skillListIds.Add(reader.ReadInt());
            }
            m_isLocked = reader.ReadBoolean();
            m_price = reader.ReadVarUhInt();
        }
    }
}
