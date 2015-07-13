//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Types.Game.Social
{
    using Common.Protocol.Network.Types.Game.Context.Roleplay;
    using Common.Protocol.Network.Types.Game.Guild;
    using System.Collections.Generic;
    using System;
    
    
    public class GuildFactSheetInformations : GuildInformations
    {
        
        public const int Id = 424;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private uint m_leaderId;
        
        public virtual uint LeaderId
        {
            get
            {
                return m_leaderId;
            }
            set
            {
                m_leaderId = value;
            }
        }
        
        private sbyte m_guildLevel;
        
        public virtual sbyte GuildLevel
        {
            get
            {
                return m_guildLevel;
            }
            set
            {
                m_guildLevel = value;
            }
        }
        
        private ushort m_nbMembers;
        
        public virtual ushort NbMembers
        {
            get
            {
                return m_nbMembers;
            }
            set
            {
                m_nbMembers = value;
            }
        }
        
        public void Initiate(uint leaderId, sbyte guildLevel, ushort nbMembers)
        {
            m_leaderId = leaderId;
            m_guildLevel = guildLevel;
            m_nbMembers = nbMembers;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(m_leaderId);
            writer.WriteSByte(m_guildLevel);
            writer.WriteVarUhShort(m_nbMembers);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            m_leaderId = reader.ReadVarUhInt();
            m_guildLevel = reader.ReadSByte();
            m_nbMembers = reader.ReadVarUhShort();
        }
    }
}
