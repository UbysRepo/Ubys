//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Context.Roleplay
{
    using Common.Protocol.Network.Types.Game.House;
    using Common.Protocol.Network.Types.Game.Context.Roleplay;
    using Common.Protocol.Network.Types.Game.Interactive;
    using Common.Protocol.Network.Types.Game.Context.Fight;
    using System.Collections.Generic;
    using System;
    
    
    public class MapComplementaryInformationsDataInHouseMessage : MapComplementaryInformationsDataMessage
    {
        
        public const int Id = 6130;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private HouseInformationsInside m_currentHouse;
        
        public virtual HouseInformationsInside CurrentHouse
        {
            get
            {
                return m_currentHouse;
            }
            set
            {
                m_currentHouse = value;
            }
        }
        
        public void Initiate(HouseInformationsInside currentHouse)
        {
            m_currentHouse = currentHouse;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            m_currentHouse.Serialize(writer);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            m_currentHouse = new HouseInformationsInside();
            m_currentHouse.Deserialize(reader);
        }
    }
}
