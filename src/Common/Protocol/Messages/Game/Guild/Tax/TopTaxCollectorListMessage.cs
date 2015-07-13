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
    using Common.Protocol.Network.Types.Game.Guild.Tax;
    using System.Collections.Generic;
    using System;
    
    
    public class TopTaxCollectorListMessage : AbstractTaxCollectorListMessage
    {
        
        public const int Id = 6565;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private bool m_isDungeon;
        
        public virtual bool IsDungeon
        {
            get
            {
                return m_isDungeon;
            }
            set
            {
                m_isDungeon = value;
            }
        }
        
        public void Initiate(bool isDungeon)
        {
            m_isDungeon = isDungeon;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(m_isDungeon);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            m_isDungeon = reader.ReadBoolean();
        }
    }
}
