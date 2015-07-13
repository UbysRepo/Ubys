//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Inventory.Items
{
    using System.Collections.Generic;
    using System;
    
    
    public class MimicryObjectErrorMessage : SymbioticObjectErrorMessage
    {
        
        public const int Id = 6461;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private bool m_preview;
        
        public virtual bool Preview
        {
            get
            {
                return m_preview;
            }
            set
            {
                m_preview = value;
            }
        }
        
        public void Initiate(bool preview)
        {
            m_preview = preview;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(m_preview);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            m_preview = reader.ReadBoolean();
        }
    }
}
