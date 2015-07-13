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
    using System.Collections.Generic;
    using System;
    
    
    public class GuildFightJoinRequestMessage : NetworkMessage
    {
        
        public const int Id = 5717;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private int m_taxCollectorId;
        
        public virtual int TaxCollectorId
        {
            get
            {
                return m_taxCollectorId;
            }
            set
            {
                m_taxCollectorId = value;
            }
        }
        
        public void Initiate(int taxCollectorId)
        {
            m_taxCollectorId = taxCollectorId;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteInt(m_taxCollectorId);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_taxCollectorId = reader.ReadInt();
        }
    }
}
