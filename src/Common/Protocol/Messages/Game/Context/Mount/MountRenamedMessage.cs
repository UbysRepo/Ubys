//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Context.Mount
{
    using System.Collections.Generic;
    using System;
    
    
    public class MountRenamedMessage : NetworkMessage
    {
        
        public const int Id = 5983;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private int m_mountId;
        
        public virtual int MountId
        {
            get
            {
                return m_mountId;
            }
            set
            {
                m_mountId = value;
            }
        }
        
        private string m_name;
        
        public virtual string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
            }
        }
        
        public void Initiate(int mountId, string name)
        {
            m_mountId = mountId;
            m_name = name;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarInt(m_mountId);
            writer.WriteUTF(m_name);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_mountId = reader.ReadVarInt();
            m_name = reader.ReadUTF();
        }
    }
}
