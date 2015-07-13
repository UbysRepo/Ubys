//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Context.Mount
{
    using System.Collections.Generic;
    using System;
    
    
    public class GameDataPaddockObjectRemoveMessage : NetworkMessage
    {
        
        public const int Id = 5993;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private ushort m_cellId;
        
        public virtual ushort CellId
        {
            get
            {
                return m_cellId;
            }
            set
            {
                m_cellId = value;
            }
        }
        
        public void Initiate(ushort cellId)
        {
            m_cellId = cellId;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarUhShort(m_cellId);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_cellId = reader.ReadVarUhShort();
        }
    }
}
