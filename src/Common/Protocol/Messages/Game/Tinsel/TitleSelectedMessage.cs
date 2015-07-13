//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Tinsel
{
    using System.Collections.Generic;
    using System;
    
    
    public class TitleSelectedMessage : NetworkMessage
    {
        
        public const int Id = 6366;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private ushort m_titleId;
        
        public virtual ushort TitleId
        {
            get
            {
                return m_titleId;
            }
            set
            {
                m_titleId = value;
            }
        }
        
        public void Initiate(ushort titleId)
        {
            m_titleId = titleId;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarUhShort(m_titleId);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_titleId = reader.ReadVarUhShort();
        }
    }
}
