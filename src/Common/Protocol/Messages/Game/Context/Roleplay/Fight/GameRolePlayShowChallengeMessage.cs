//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Context.Roleplay.Fight
{
    using Common.Protocol.Network.Types.Game.Context.Fight;
    using System.Collections.Generic;
    using System;
    
    
    public class GameRolePlayShowChallengeMessage : NetworkMessage
    {
        
        public const int Id = 301;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private FightCommonInformations m_commonsInfos;
        
        public virtual FightCommonInformations CommonsInfos
        {
            get
            {
                return m_commonsInfos;
            }
            set
            {
                m_commonsInfos = value;
            }
        }
        
        public void Initiate(FightCommonInformations commonsInfos)
        {
            m_commonsInfos = commonsInfos;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            m_commonsInfos.Serialize(writer);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_commonsInfos = new FightCommonInformations();
            m_commonsInfos.Deserialize(reader);
        }
    }
}
