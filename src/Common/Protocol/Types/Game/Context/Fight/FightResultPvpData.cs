//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Types.Game.Context.Fight
{
    using System.Collections.Generic;
    using System;
    
    
    public class FightResultPvpData : FightResultAdditionalData
    {
        
        public const int Id = 190;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private sbyte m_grade;
        
        public virtual sbyte Grade
        {
            get
            {
                return m_grade;
            }
            set
            {
                m_grade = value;
            }
        }
        
        private ushort m_minHonorForGrade;
        
        public virtual ushort MinHonorForGrade
        {
            get
            {
                return m_minHonorForGrade;
            }
            set
            {
                m_minHonorForGrade = value;
            }
        }
        
        private ushort m_maxHonorForGrade;
        
        public virtual ushort MaxHonorForGrade
        {
            get
            {
                return m_maxHonorForGrade;
            }
            set
            {
                m_maxHonorForGrade = value;
            }
        }
        
        private ushort m_honor;
        
        public virtual ushort Honor
        {
            get
            {
                return m_honor;
            }
            set
            {
                m_honor = value;
            }
        }
        
        private short m_honorDelta;
        
        public virtual short HonorDelta
        {
            get
            {
                return m_honorDelta;
            }
            set
            {
                m_honorDelta = value;
            }
        }
        
        public void Initiate(sbyte grade, ushort minHonorForGrade, ushort maxHonorForGrade, ushort honor, short honorDelta)
        {
            m_grade = grade;
            m_minHonorForGrade = minHonorForGrade;
            m_maxHonorForGrade = maxHonorForGrade;
            m_honor = honor;
            m_honorDelta = honorDelta;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(m_grade);
            writer.WriteVarUhShort(m_minHonorForGrade);
            writer.WriteVarUhShort(m_maxHonorForGrade);
            writer.WriteVarUhShort(m_honor);
            writer.WriteVarShort(m_honorDelta);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            m_grade = reader.ReadSByte();
            m_minHonorForGrade = reader.ReadVarUhShort();
            m_maxHonorForGrade = reader.ReadVarUhShort();
            m_honor = reader.ReadVarUhShort();
            m_honorDelta = reader.ReadVarShort();
        }
    }
}
