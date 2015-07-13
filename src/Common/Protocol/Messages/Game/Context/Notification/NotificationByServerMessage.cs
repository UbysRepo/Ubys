//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Context.Notification
{
    using System.Collections.Generic;
    using System;
    
    
    public class NotificationByServerMessage : NetworkMessage
    {
        
        public const int Id = 6103;
        
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
        
        private List<System.String> m_parameters;
        
        public virtual List<System.String> Parameters
        {
            get
            {
                return m_parameters;
            }
            set
            {
                m_parameters = value;
            }
        }
        
        private bool m_forceOpen;
        
        public virtual bool ForceOpen
        {
            get
            {
                return m_forceOpen;
            }
            set
            {
                m_forceOpen = value;
            }
        }
        
        public void Initiate(ushort objectId, List<System.String> parameters, bool forceOpen)
        {
            m_ObjectId = objectId;
            m_parameters = parameters;
            m_forceOpen = forceOpen;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarUhShort(m_ObjectId);
            writer.WriteShort(((short)(m_parameters.Count)));
            int parametersIndex;
            for (parametersIndex = 0; (parametersIndex < m_parameters.Count); parametersIndex = (parametersIndex + 1))
            {
                writer.WriteUTF(m_parameters[parametersIndex]);
            }
            writer.WriteBoolean(m_forceOpen);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_ObjectId = reader.ReadVarUhShort();
            int parametersCount = reader.ReadUShort();
            int parametersIndex;
            m_parameters = new System.Collections.Generic.List<string>();
            for (parametersIndex = 0; (parametersIndex < parametersCount); parametersIndex = (parametersIndex + 1))
            {
                m_parameters.Add(reader.ReadUTF());
            }
            m_forceOpen = reader.ReadBoolean();
        }
    }
}
