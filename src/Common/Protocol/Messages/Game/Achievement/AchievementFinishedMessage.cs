//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Achievement
{
    using System.Collections.Generic;
    using System;
    
    
    public class AchievementFinishedMessage : NetworkMessage
    {
        
        public const int Id = 6208;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private ushort m_ObjectId;
        
        public virtual ushort ObjectId
        {
            get
            {
                return m_ObjectId;
            }
            set
            {
                m_ObjectId = value;
            }
        }
        
        private sbyte m_finishedlevel;
        
        public virtual sbyte Finishedlevel
        {
            get
            {
                return m_finishedlevel;
            }
            set
            {
                m_finishedlevel = value;
            }
        }
        
        public void Initiate(ushort objectId, sbyte finishedlevel)
        {
            m_ObjectId = objectId;
            m_finishedlevel = finishedlevel;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarUhShort(m_ObjectId);
            writer.WriteSByte(m_finishedlevel);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_ObjectId = reader.ReadVarUhShort();
            m_finishedlevel = reader.ReadSByte();
        }
    }
}
