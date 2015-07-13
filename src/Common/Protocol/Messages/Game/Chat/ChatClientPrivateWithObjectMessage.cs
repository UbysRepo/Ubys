//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Chat
{
    using Common.Protocol.Network.Types.Game.Data.Items;
    using System.Collections.Generic;
    using System;
    
    
    public class ChatClientPrivateWithObjectMessage : ChatClientPrivateMessage
    {
        
        public const int Id = 852;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private List<ObjectItem> m_objects;
        
        public virtual List<ObjectItem> Objects
        {
            get
            {
                return m_objects;
            }
            set
            {
                m_objects = value;
            }
        }
        
        public void Initiate(List<ObjectItem> objects)
        {
            m_objects = objects;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(((short)(m_objects.Count)));
            int objectsIndex;
            for (objectsIndex = 0; (objectsIndex < m_objects.Count); objectsIndex = (objectsIndex + 1))
            {
                ObjectItem objectToSend = m_objects[objectsIndex];
                objectToSend.Serialize(writer);
            }
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            int objectsCount = reader.ReadUShort();
            int objectsIndex;
            m_objects = new System.Collections.Generic.List<ObjectItem>();
            for (objectsIndex = 0; (objectsIndex < objectsCount); objectsIndex = (objectsIndex + 1))
            {
                ObjectItem objectToAdd = new ObjectItem();
                objectToAdd.Deserialize(reader);
                m_objects.Add(objectToAdd);
            }
        }
    }
}
