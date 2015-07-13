using System;
namespace World.Handlers
{
    /// <summary>
    /// Attribut qui servira a gerer la reception de messages par la suite
    /// </summary>
    public class MessageHandler : Attribute
    {
        public uint MessageId
        {
            get;
            set;
        }
        public MessageHandler(uint messageId)
        {
            this.MessageId = messageId;
        }
        public override string ToString()
        {
            return this.MessageId.ToString();
        }
    }
}
