//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Actions.Fight
{
    using Common.Protocol.Network.Messages.Game.Actions;
    using Common.Protocol.Network.Types.Game.Actions.Fight;
    using System.Collections.Generic;
    using System;
    
    
    public class GameActionFightMarkCellsMessage : AbstractGameActionMessage
    {
        
        public const int Id = 5540;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private GameActionMark m_mark;
        
        public virtual GameActionMark Mark
        {
            get
            {
                return m_mark;
            }
            set
            {
                m_mark = value;
            }
        }
        
        public void Initiate(GameActionMark mark)
        {
            m_mark = mark;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            m_mark.Serialize(writer);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            m_mark = new GameActionMark();
            m_mark.Deserialize(reader);
        }
    }
}
