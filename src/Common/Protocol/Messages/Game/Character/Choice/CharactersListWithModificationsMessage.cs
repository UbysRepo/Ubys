//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18063
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Protocol.Network.Messages.Game.Character.Choice
{
    using Common.Protocol.Network.Types.Game.Character.Choice;
    using System.Collections.Generic;
    using System;
    
    
    public class CharactersListWithModificationsMessage : CharactersListMessage
    {
        
        public const int Id = 6120;
        
        public override int ProtocolId
        {
            get
            {
                return Id;
            }
        }
        
        private List<CharacterToRecolorInformation> m_charactersToRecolor;
        
        public virtual List<CharacterToRecolorInformation> CharactersToRecolor
        {
            get
            {
                return m_charactersToRecolor;
            }
            set
            {
                m_charactersToRecolor = value;
            }
        }
        
        private List<System.Int32> m_charactersToRename;
        
        public virtual List<System.Int32> CharactersToRename
        {
            get
            {
                return m_charactersToRename;
            }
            set
            {
                m_charactersToRename = value;
            }
        }
        
        private List<System.Int32> m_unusableCharacters;
        
        public virtual List<System.Int32> UnusableCharacters
        {
            get
            {
                return m_unusableCharacters;
            }
            set
            {
                m_unusableCharacters = value;
            }
        }
        
        private List<CharacterToRelookInformation> m_charactersToRelook;
        
        public virtual List<CharacterToRelookInformation> CharactersToRelook
        {
            get
            {
                return m_charactersToRelook;
            }
            set
            {
                m_charactersToRelook = value;
            }
        }
        
        public void Initiate(List<CharacterToRecolorInformation> charactersToRecolor, List<System.Int32> charactersToRename, List<System.Int32> unusableCharacters, List<CharacterToRelookInformation> charactersToRelook)
        {
            m_charactersToRecolor = charactersToRecolor;
            m_charactersToRename = charactersToRename;
            m_unusableCharacters = unusableCharacters;
            m_charactersToRelook = charactersToRelook;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(((short)(m_charactersToRecolor.Count)));
            int charactersToRecolorIndex;
            for (charactersToRecolorIndex = 0; (charactersToRecolorIndex < m_charactersToRecolor.Count); charactersToRecolorIndex = (charactersToRecolorIndex + 1))
            {
                CharacterToRecolorInformation objectToSend = m_charactersToRecolor[charactersToRecolorIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteShort(((short)(m_charactersToRename.Count)));
            int charactersToRenameIndex;
            for (charactersToRenameIndex = 0; (charactersToRenameIndex < m_charactersToRename.Count); charactersToRenameIndex = (charactersToRenameIndex + 1))
            {
                writer.WriteInt(m_charactersToRename[charactersToRenameIndex]);
            }
            writer.WriteShort(((short)(m_unusableCharacters.Count)));
            int unusableCharactersIndex;
            for (unusableCharactersIndex = 0; (unusableCharactersIndex < m_unusableCharacters.Count); unusableCharactersIndex = (unusableCharactersIndex + 1))
            {
                writer.WriteInt(m_unusableCharacters[unusableCharactersIndex]);
            }
            writer.WriteShort(((short)(m_charactersToRelook.Count)));
            int charactersToRelookIndex;
            for (charactersToRelookIndex = 0; (charactersToRelookIndex < m_charactersToRelook.Count); charactersToRelookIndex = (charactersToRelookIndex + 1))
            {
                CharacterToRelookInformation objectToSend = m_charactersToRelook[charactersToRelookIndex];
                objectToSend.Serialize(writer);
            }
        }
        
        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);
            int charactersToRecolorCount = reader.ReadUShort();
            int charactersToRecolorIndex;
            m_charactersToRecolor = new System.Collections.Generic.List<CharacterToRecolorInformation>();
            for (charactersToRecolorIndex = 0; (charactersToRecolorIndex < charactersToRecolorCount); charactersToRecolorIndex = (charactersToRecolorIndex + 1))
            {
                CharacterToRecolorInformation objectToAdd = new CharacterToRecolorInformation();
                objectToAdd.Deserialize(reader);
                m_charactersToRecolor.Add(objectToAdd);
            }
            int charactersToRenameCount = reader.ReadUShort();
            int charactersToRenameIndex;
            m_charactersToRename = new System.Collections.Generic.List<int>();
            for (charactersToRenameIndex = 0; (charactersToRenameIndex < charactersToRenameCount); charactersToRenameIndex = (charactersToRenameIndex + 1))
            {
                m_charactersToRename.Add(reader.ReadInt());
            }
            int unusableCharactersCount = reader.ReadUShort();
            int unusableCharactersIndex;
            m_unusableCharacters = new System.Collections.Generic.List<int>();
            for (unusableCharactersIndex = 0; (unusableCharactersIndex < unusableCharactersCount); unusableCharactersIndex = (unusableCharactersIndex + 1))
            {
                m_unusableCharacters.Add(reader.ReadInt());
            }
            int charactersToRelookCount = reader.ReadUShort();
            int charactersToRelookIndex;
            m_charactersToRelook = new System.Collections.Generic.List<CharacterToRelookInformation>();
            for (charactersToRelookIndex = 0; (charactersToRelookIndex < charactersToRelookCount); charactersToRelookIndex = (charactersToRelookIndex + 1))
            {
                CharacterToRelookInformation objectToAdd = new CharacterToRelookInformation();
                objectToAdd.Deserialize(reader);
                m_charactersToRelook.Add(objectToAdd);
            }
        }
    }
}
