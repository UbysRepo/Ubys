//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Types.Game.Context.Roleplay
{
    using System.Collections.Generic;
    using System;
    
    
    public class HumanOptionEmote : HumanOption
    {
        
        public const int Id = 407;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private sbyte m_emoteId;
        
        public virtual sbyte EmoteId
        {
            get
            {
                return m_emoteId;
            }
            set
            {
                m_emoteId = value;
            }
        }
        
        private double m_emoteStartTime;
        
        public virtual double EmoteStartTime
        {
            get
            {
                return m_emoteStartTime;
            }
            set
            {
                m_emoteStartTime = value;
            }
        }
        
        public void Initiate(sbyte emoteId, double emoteStartTime)
        {
            m_emoteId = emoteId;
            m_emoteStartTime = emoteStartTime;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(m_emoteId);
            writer.WriteDouble(m_emoteStartTime);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            m_emoteId = reader.ReadSByte();
            m_emoteStartTime = reader.ReadDouble();
        }
    }
}
