//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Protocol.Messages.Connection.Register
{
    using System.Collections.Generic;
    using System;
    using Protocol.IO.BigEndian;
    
    
    public class NicknameRegistrationMessage : AbstractAbstractNetworkMessage
    {
        
        public const int Id = 5640;
        
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
        
        public override void Serialize(BigEndianWriter writer)
        {
        }
        
        public override void Deserialize(BigEndianReader reader)
        {
        }
    }
}
