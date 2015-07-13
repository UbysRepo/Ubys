//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Context.Roleplay.Fight
{
    using System.Collections.Generic;
    using System;
    
    
    public class GameRolePlayPlayerFightRequestMessage : NetworkMessage
    {
        
        public const int Id = 5731;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
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
        
        private short m_targetCellId;
        
        public virtual short TargetCellId
        {
            get
            {
                return m_targetCellId;
            }
            set
            {
                m_targetCellId = value;
            }
        }
        
        private bool m_friendly;
        
        public virtual bool Friendly
        {
            get
            {
                return m_friendly;
            }
            set
            {
                m_friendly = value;
            }
        }
        
        public void Initiate(uint targetId, short targetCellId, bool friendly)
        {
            m_targetId = targetId;
            m_targetCellId = targetCellId;
            m_friendly = friendly;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarUhInt(m_targetId);
            writer.WriteShort(m_targetCellId);
            writer.WriteBoolean(m_friendly);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_targetId = reader.ReadVarUhInt();
            m_targetCellId = reader.ReadShort();
            m_friendly = reader.ReadBoolean();
        }
    }
}
