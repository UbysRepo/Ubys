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
    
    
    public class GameCautiousMapMovementMessage : GameMapMovementMessage
    {
        
        public const int Id = 6497;
        
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
            base.Serialize(writer);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
        }
    }
}
