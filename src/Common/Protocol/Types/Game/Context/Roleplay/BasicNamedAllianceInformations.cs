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
    
    
    public class BasicNamedAllianceInformations : BasicAllianceInformations
    {
        
        public const int Id = 418;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private string m_allianceName;
        
        public virtual string AllianceName
        {
            get
            {
                return m_allianceName;
            }
            set
            {
                m_allianceName = value;
            }
        }
        
        public void Initiate(string allianceName)
        {
            m_allianceName = allianceName;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(m_allianceName);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            m_allianceName = reader.ReadUTF();
        }
    }
}
