//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Basic
{
    using System.Collections.Generic;
    using System;
    
    
    public class BasicLatencyStatsRequestMessage : NetworkMessage
    {
        
        public const int Id = 5816;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        public void Initiate()
        {
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
        }
    }
}
