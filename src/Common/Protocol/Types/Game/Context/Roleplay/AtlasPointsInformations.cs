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
    using Common.Protocol.Network.Types.Game.Context;
    using System.Collections.Generic;
    using System;
    
    
    public class AtlasPointsInformations : NetworkType
    {
        
        public const int Id = 175;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private byte m_type;
        
        public virtual byte Type
        {
            get
            {
                return m_type;
            }
            set
            {
                m_type = value;
            }
        }
        
        private List<MapCoordinatesExtended> m_coords;
        
        public virtual List<MapCoordinatesExtended> Coords
        {
            get
            {
                return m_coords;
            }
            set
            {
                m_coords = value;
            }
        }
        
        public void Initiate(byte type, List<MapCoordinatesExtended> coords)
        {
            m_type = type;
            m_coords = coords;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteByte(m_type);
            writer.WriteShort(((short)(m_coords.Count)));
            int coordsIndex;
            for (coordsIndex = 0; (coordsIndex < m_coords.Count); coordsIndex = (coordsIndex + 1))
            {
                MapCoordinatesExtended objectToSend = m_coords[coordsIndex];
                objectToSend.Serialize(writer);
            }
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_type = reader.ReadByte();
            int coordsCount = reader.ReadUShort();
            int coordsIndex;
            m_coords = new System.Collections.Generic.List<MapCoordinatesExtended>();
            for (coordsIndex = 0; (coordsIndex < coordsCount); coordsIndex = (coordsIndex + 1))
            {
                MapCoordinatesExtended objectToAdd = new MapCoordinatesExtended();
                objectToAdd.Deserialize(reader);
                m_coords.Add(objectToAdd);
            }
        }
    }
}
