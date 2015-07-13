//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Interactive
{
    using Common.Protocol.Network.Types.Game.Interactive;
    using Common.Protocol.Network;
    using System.Collections.Generic;
    using System;
    
    
    public class InteractiveMapUpdateMessage : NetworkMessage
    {
        
        public const int Id = 5002;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private List<InteractiveElement> m_interactiveElements;
        
        public virtual List<InteractiveElement> InteractiveElements
        {
            get
            {
                return m_interactiveElements;
            }
            set
            {
                m_interactiveElements = value;
            }
        }
        
        public void Initiate(List<InteractiveElement> interactiveElements)
        {
            m_interactiveElements = interactiveElements;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteShort(((short)(m_interactiveElements.Count)));
            int interactiveElementsIndex;
            for (interactiveElementsIndex = 0; (interactiveElementsIndex < m_interactiveElements.Count); interactiveElementsIndex = (interactiveElementsIndex + 1))
            {
                InteractiveElement objectToSend = m_interactiveElements[interactiveElementsIndex];
                writer.WriteUShort(((ushort)(objectToSend.ProtocolId)));
                objectToSend.Serialize(writer);
            }
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            int interactiveElementsCount = reader.ReadUShort();
            int interactiveElementsIndex;
            m_interactiveElements = new System.Collections.Generic.List<InteractiveElement>();
            for (interactiveElementsIndex = 0; (interactiveElementsIndex < interactiveElementsCount); interactiveElementsIndex = (interactiveElementsIndex + 1))
            {
                InteractiveElement objectToAdd = ProtocolManager.GetTypeInstance<InteractiveElement>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                m_interactiveElements.Add(objectToAdd);
            }
        }
    }
}
