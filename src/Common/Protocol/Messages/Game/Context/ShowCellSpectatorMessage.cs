//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Context
{
    using System.Collections.Generic;
    using System;
    
    
    public class ShowCellSpectatorMessage : ShowCellMessage
    {
        
        public const int Id = 6158;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private string m_playerName;
        
        public virtual string PlayerName
        {
            get
            {
                return m_playerName;
            }
            set
            {
                m_playerName = value;
            }
        }
        
        public void Initiate(string playerName)
        {
            m_playerName = playerName;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(m_playerName);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            m_playerName = reader.ReadUTF();
        }
    }
}
