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
    using Common.Protocol.Network.Types.Game.Look;
    using Common.Protocol.Network.Types.Game.Character.Status;
    using Common.Protocol.Network.Types.Game.Context.Roleplay.Party.Companion;
    using Common.Protocol.Network;
    using System.Collections.Generic;
    using System;
    
    
    public class PartyGuestInformations : NetworkType
    {
        
        public const int Id = 374;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private int m_guestId;
        
        public virtual int GuestId
        {
            get
            {
                return m_guestId;
            }
            set
            {
                m_guestId = value;
            }
        }
        
        private int m_hostId;
        
        public virtual int HostId
        {
            get
            {
                return m_hostId;
            }
            set
            {
                m_hostId = value;
            }
        }
        
        private string m_name;
        
        public virtual string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
            }
        }
        
        private EntityLook m_guestLook;
        
        public virtual EntityLook GuestLook
        {
            get
            {
                return m_guestLook;
            }
            set
            {
                m_guestLook = value;
            }
        }
        
        private byte m_breed;
        
        public virtual byte Breed
        {
            get
            {
                return m_breed;
            }
            set
            {
                m_breed = value;
            }
        }
        
        private bool m_sex;
        
        public virtual bool Sex
        {
            get
            {
                return m_sex;
            }
            set
            {
                m_sex = value;
            }
        }
        
        private PlayerStatus m_status;
        
        public virtual PlayerStatus Status
        {
            get
            {
                return m_status;
            }
            set
            {
                m_status = value;
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
        
        public void Initiate(int guestId, int hostId, string name, EntityLook guestLook, byte breed, bool sex, PlayerStatus status, List<PartyCompanionBaseInformations> companions)
        {
            m_guestId = guestId;
            m_hostId = hostId;
            m_name = name;
            m_guestLook = guestLook;
            m_breed = breed;
            m_sex = sex;
            m_status = status;
            m_companions = companions;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteInt(m_guestId);
            writer.WriteInt(m_hostId);
            writer.WriteUTF(m_name);
            m_guestLook.Serialize(writer);
            writer.WriteByte(m_breed);
            writer.WriteBoolean(m_sex);
            writer.WriteUShort(((ushort)(m_status.ProtocolId)));
            m_status.Serialize(writer);
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
            m_guestId = reader.ReadInt();
            m_hostId = reader.ReadInt();
            m_name = reader.ReadUTF();
            m_guestLook = new EntityLook();
            m_guestLook.Deserialize(reader);
            m_breed = reader.ReadByte();
            m_sex = reader.ReadBoolean();
            m_status = ProtocolManager.GetTypeInstance<PlayerStatus>(reader.ReadUShort());
            m_status.Deserialize(reader);
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
