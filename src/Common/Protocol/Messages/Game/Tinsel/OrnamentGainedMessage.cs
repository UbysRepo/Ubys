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
    
    
    public class OrnamentGainedMessage : NetworkMessage
    {
        
        public const int Id = 6368;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private short m_ornamentId;
        
        public virtual short OrnamentId
        {
            get
            {
                return m_ornamentId;
            }
            set
            {
                m_ornamentId = value;
            }
        }
        
        public void Initiate(short ornamentId)
        {
            m_ornamentId = ornamentId;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteShort(m_ornamentId);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_ornamentId = reader.ReadShort();
        }
    }
}
