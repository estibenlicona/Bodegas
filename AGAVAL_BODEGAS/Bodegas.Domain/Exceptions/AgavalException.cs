using System.Runtime.Serialization;

namespace Bodegas.Domain.Exceptions
{
    [Serializable]
    public class AgavalException : Exception
    {
        public AgavalException() { }
        public AgavalException(string message) : base(message) { }
        public AgavalException(string message, Exception inner) : base(message, inner) { }
        protected AgavalException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
