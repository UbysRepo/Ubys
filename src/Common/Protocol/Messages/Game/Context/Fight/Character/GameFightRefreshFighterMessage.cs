//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Context.Fight.Character
{
    using Common.Protocol.Network.Types.Game.Context;
    using Common.Protocol.Network;
    using System.Collections.Generic;
    using System;
    
    
    public class GameFightRefreshFighterMessage : NetworkMessage
    {
        
        public const int Id = 6309;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private GameContextActorInformations m_informations;
        
        public virtual GameContextActorInformations Informations
        {
            get
            {
                return m_informations;
            }
            set
            {
                m_informations = value;
            }
        }
        
        public void Initiate(GameContextActorInformations informations)
        {
            m_informations = informations;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteUShort(((ushort)(m_informations.ProtocolId)));
            m_informations.Serialize(writer);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_informations = ProtocolManager.GetTypeInstance<GameContextActorInformations>(reader.ReadUShort());
            m_informations.Deserialize(reader);
        }
    }
}
