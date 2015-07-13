//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Connection
{
    using System.Collections.Generic;
    using System;
    
    
    public class SelectedServerDataMessage : NetworkMessage
    {
        
        public const int Id = 42;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private ushort m_serverId;
        
        public virtual ushort ServerId
        {
            get
            {
                return m_serverId;
            }
            set
            {
                m_serverId = value;
            }
        }
        
        private string m_address;
        
        public virtual string Address
        {
            get
            {
                return m_address;
            }
            set
            {
                m_address = value;
            }
        }
        
        private ushort m_port;
        
        public virtual ushort Port
        {
            get
            {
                return m_port;
            }
            set
            {
                m_port = value;
            }
        }
        
        private bool m_canCreateNewCharacter;
        
        public virtual bool CanCreateNewCharacter
        {
            get
            {
                return m_canCreateNewCharacter;
            }
            set
            {
                m_canCreateNewCharacter = value;
            }
        }
        
        private List<System.Byte> m_ticket;
        
        public virtual List<System.Byte> Ticket
        {
            get
            {
                return m_ticket;
            }
            set
            {
                m_ticket = value;
            }
        }
        
        public void Initiate(ushort serverId, string address, ushort port, bool canCreateNewCharacter, List<System.Byte> ticket)
        {
            m_serverId = serverId;
            m_address = address;
            m_port = port;
            m_canCreateNewCharacter = canCreateNewCharacter;
            m_ticket = ticket;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarUhShort(m_serverId);
            writer.WriteUTF(m_address);
            writer.WriteUShort(m_port);
            writer.WriteBoolean(m_canCreateNewCharacter);
            writer.WriteShort(((short)(m_ticket.Count)));
            int ticketIndex;
            for (ticketIndex = 0; (ticketIndex < m_ticket.Count); ticketIndex = (ticketIndex + 1))
            {
                writer.WriteByte(m_ticket[ticketIndex]);
            }
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_serverId = reader.ReadVarUhShort();
            m_address = reader.ReadUTF();
            m_port = reader.ReadUShort();
            m_canCreateNewCharacter = reader.ReadBoolean();
            int ticketCount = reader.ReadUShort();
            int ticketIndex;
            m_ticket = new System.Collections.Generic.List<byte>();
            for (ticketIndex = 0; (ticketIndex < ticketCount); ticketIndex = (ticketIndex + 1))
            {
                m_ticket.Add(reader.ReadByte());
            }
        }
    }
}
