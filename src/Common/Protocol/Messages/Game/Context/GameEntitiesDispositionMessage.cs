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
    
    
    public class GameEntitiesDispositionMessage : NetworkMessage
    {
        
        public const int Id = 5696;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private List<IdentifiedEntityDispositionInformations> m_dispositions;
        
        public virtual List<IdentifiedEntityDispositionInformations> Dispositions
        {
            get
            {
                return m_dispositions;
            }
            set
            {
                m_dispositions = value;
            }
        }
        
        public void Initiate(List<IdentifiedEntityDispositionInformations> dispositions)
        {
            m_dispositions = dispositions;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteShort(((short)(m_dispositions.Count)));
            int dispositionsIndex;
            for (dispositionsIndex = 0; (dispositionsIndex < m_dispositions.Count); dispositionsIndex = (dispositionsIndex + 1))
            {
                IdentifiedEntityDispositionInformations objectToSend = m_dispositions[dispositionsIndex];
                objectToSend.Serialize(writer);
            }
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            int dispositionsCount = reader.ReadUShort();
            int dispositionsIndex;
            m_dispositions = new System.Collections.Generic.List<IdentifiedEntityDispositionInformations>();
            for (dispositionsIndex = 0; (dispositionsIndex < dispositionsCount); dispositionsIndex = (dispositionsIndex + 1))
            {
                IdentifiedEntityDispositionInformations objectToAdd = new IdentifiedEntityDispositionInformations();
                objectToAdd.Deserialize(reader);
                m_dispositions.Add(objectToAdd);
            }
        }
    }
}
