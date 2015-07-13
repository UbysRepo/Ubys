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
    using Common.Protocol.Network.Types.Game.Character.Alignment;
    using Common.Protocol.Network.Types.Game.Look;
    using Common.Protocol.Network.Types.Game.Context;
    using System.Collections.Generic;
    using System;
    
    
    public class GameRolePlayCharacterInformations : GameRolePlayHumanoidInformations
    {
        
        public const int Id = 36;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private ActorAlignmentInformations m_alignmentInfos;
        
        public virtual ActorAlignmentInformations AlignmentInfos
        {
            get
            {
                return m_alignmentInfos;
            }
            set
            {
                m_alignmentInfos = value;
            }
        }
        
        public void Initiate(ActorAlignmentInformations alignmentInfos)
        {
            m_alignmentInfos = alignmentInfos;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            m_alignmentInfos.Serialize(writer);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            m_alignmentInfos = new ActorAlignmentInformations();
            m_alignmentInfos.Deserialize(reader);
        }
    }
}
