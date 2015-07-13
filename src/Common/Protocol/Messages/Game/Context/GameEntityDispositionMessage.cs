//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Context
{
    using Common.Protocol.Network.Types.Game.Context;
    using System.Collections.Generic;
    using System;
    
    
    public class GameEntityDispositionMessage : NetworkMessage
    {
        
        public const int Id = 5693;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private IdentifiedEntityDispositionInformations m_disposition;
        
        public virtual IdentifiedEntityDispositionInformations Disposition
        {
            get
            {
                return m_disposition;
            }
            set
            {
                m_disposition = value;
            }
        }
        
        public void Initiate(IdentifiedEntityDispositionInformations disposition)
        {
            m_disposition = disposition;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            m_disposition.Serialize(writer);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_disposition = new IdentifiedEntityDispositionInformations();
            m_disposition.Deserialize(reader);
        }
    }
}
