//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Common.Protocol.Network.Types.Game.Mount;
    using System.Collections.Generic;
    using System;
    
    
    public class ExchangeStartOkMountMessage : ExchangeStartOkMountWithOutPaddockMessage
    {
        
        public const int Id = 5979;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private List<MountClientData> m_paddockedMountsDescription;
        
        public virtual List<MountClientData> PaddockedMountsDescription
        {
            get
            {
                return m_paddockedMountsDescription;
            }
            set
            {
                m_paddockedMountsDescription = value;
            }
        }
        
        public void Initiate(List<MountClientData> paddockedMountsDescription)
        {
            m_paddockedMountsDescription = paddockedMountsDescription;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(((short)(m_paddockedMountsDescription.Count)));
            int paddockedMountsDescriptionIndex;
            for (paddockedMountsDescriptionIndex = 0; (paddockedMountsDescriptionIndex < m_paddockedMountsDescription.Count); paddockedMountsDescriptionIndex = (paddockedMountsDescriptionIndex + 1))
            {
                MountClientData objectToSend = m_paddockedMountsDescription[paddockedMountsDescriptionIndex];
                objectToSend.Serialize(writer);
            }
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            int paddockedMountsDescriptionCount = reader.ReadUShort();
            int paddockedMountsDescriptionIndex;
            m_paddockedMountsDescription = new System.Collections.Generic.List<MountClientData>();
            for (paddockedMountsDescriptionIndex = 0; (paddockedMountsDescriptionIndex < paddockedMountsDescriptionCount); paddockedMountsDescriptionIndex = (paddockedMountsDescriptionIndex + 1))
            {
                MountClientData objectToAdd = new MountClientData();
                objectToAdd.Deserialize(reader);
                m_paddockedMountsDescription.Add(objectToAdd);
            }
        }
    }
}
