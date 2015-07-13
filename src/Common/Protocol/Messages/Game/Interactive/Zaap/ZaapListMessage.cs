//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Interactive.Zaap
{
    using System.Collections.Generic;
    using System;
    
    
    public class ZaapListMessage : TeleportDestinationsListMessage
    {
        
        public const int Id = 1604;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private int m_spawnMapId;
        
        public virtual int SpawnMapId
        {
            get
            {
                return m_spawnMapId;
            }
            set
            {
                m_spawnMapId = value;
            }
        }
        
        public void Initiate(int spawnMapId)
        {
            m_spawnMapId = spawnMapId;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(m_spawnMapId);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            m_spawnMapId = reader.ReadInt();
        }
    }
}
