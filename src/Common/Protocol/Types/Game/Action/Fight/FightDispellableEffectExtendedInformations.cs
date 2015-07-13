//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Types.Game.Action.Fight
{
    using Common.Protocol.Network.Types.Game.Actions.Fight;
    using Common.Protocol.Network;
    using System.Collections.Generic;
    using System;
    
    
    public class FightDispellableEffectExtendedInformations : NetworkType
    {
        
        public const int Id = 208;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private ushort m_actionId;
        
        public virtual ushort ActionId
        {
            get
            {
                return m_actionId;
            }
            set
            {
                m_actionId = value;
            }
        }
        
        private int m_sourceId;
        
        public virtual int SourceId
        {
            get
            {
                return m_sourceId;
            }
            set
            {
                m_sourceId = value;
            }
        }
        
        private AbstractFightDispellableEffect m_effect;
        
        public virtual AbstractFightDispellableEffect Effect
        {
            get
            {
                return m_effect;
            }
            set
            {
                m_effect = value;
            }
        }
        
        public void Initiate(ushort actionId, int sourceId, AbstractFightDispellableEffect effect)
        {
            m_actionId = actionId;
            m_sourceId = sourceId;
            m_effect = effect;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            writer.WriteVarUhShort(m_actionId);
            writer.WriteInt(m_sourceId);
            writer.WriteUShort(((ushort)(m_effect.ProtocolId)));
            m_effect.Serialize(writer);
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            m_actionId = reader.ReadVarUhShort();
            m_sourceId = reader.ReadInt();
            m_effect = ProtocolManager.GetTypeInstance<AbstractFightDispellableEffect>(reader.ReadUShort());
            m_effect.Deserialize(reader);
        }
    }
}
