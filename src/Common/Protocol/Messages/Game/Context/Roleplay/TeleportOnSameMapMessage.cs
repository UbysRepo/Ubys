//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Context.Roleplay
{
    using System.Collections.Generic;
    using System;
    
    
    public class TeleportOnSameMapMessage : NetworkMessage
    {
        
        public const int Id = 6048;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private int m_targetId;
        
        public virtual int TargetId
        {
            get
            {
                return m_targetId;
            }
            set
            {
                m_targetId = value;
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
        
        public void Initiate(int targetId, ushort cellId)
        {
            m_targetId = targetId;
            m_cellId = cellId;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteInt(m_targetId);
            writer.WriteVarUhShort(m_cellId);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_targetId = reader.ReadInt();
            m_cellId = reader.ReadVarUhShort();
        }
    }
}
