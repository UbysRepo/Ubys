//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Context.Roleplay.Job
{
    using Common.Protocol.Network.Types.Game.Context.Roleplay.Job;
    using System.Collections.Generic;
    using System;
    
    
    public class JobExperienceUpdateMessage : NetworkMessage
    {
        
        public const int Id = 5654;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private JobExperience m_experiencesUpdate;
        
        public virtual JobExperience ExperiencesUpdate
        {
            get
            {
                return m_experiencesUpdate;
            }
            set
            {
                m_experiencesUpdate = value;
            }
        }
        
        public void Initiate(JobExperience experiencesUpdate)
        {
            m_experiencesUpdate = experiencesUpdate;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            m_experiencesUpdate.Serialize(writer);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_experiencesUpdate = new JobExperience();
            m_experiencesUpdate.Deserialize(reader);
        }
    }
}
