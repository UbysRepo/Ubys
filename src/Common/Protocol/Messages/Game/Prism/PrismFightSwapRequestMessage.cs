//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Prism
{
    using System.Collections.Generic;
    using System;
    
    
    public class PrismFightSwapRequestMessage : NetworkMessage
    {
        
        public const int Id = 5901;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
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
        
        private uint m_targetId;
        
        public virtual uint TargetId
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
        
        public void Initiate(ushort subAreaId, uint targetId)
        {
            m_subAreaId = subAreaId;
            m_targetId = targetId;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarUhShort(m_subAreaId);
            writer.WriteVarUhInt(m_targetId);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_subAreaId = reader.ReadVarUhShort();
            m_targetId = reader.ReadVarUhInt();
        }
    }
}
