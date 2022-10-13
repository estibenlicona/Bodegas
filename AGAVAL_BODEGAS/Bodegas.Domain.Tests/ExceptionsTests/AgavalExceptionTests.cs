using Bodegas.Domain.Exceptions;
using System.Runtime.Serialization;

namespace Bodegas.Domain.Tests.ExceptionsTests
{
    [TestClass]
    public class AgavalExceptionTests
    {

        [TestMethod]
        public void AgavalException()
        {
            AgavalException agavalException = new AgavalException();
            Assert.IsNotNull(agavalException);
        }

        [TestMethod]
        public void AgavalException_With_Message()
        {
            string Message = "message exception";
            AgavalException agavalException = new AgavalException(message: Message);
            Assert.AreEqual(Message, agavalException.Message);
        }

        [TestMethod]
        public void AgavalException_With_MessageInner()
        {
            string Message = "message exception";
            Exception innerException = new Exception(Message);
            AgavalException agavalException = new AgavalException(message: Message, inner: innerException);
            Assert.AreEqual(agavalException.Message, Message);
            Assert.AreEqual(innerException.Message, Message);
        }

        [TestMethod]
        public void AgavalException_With_InfoContext()
        {
            SerializationInfo info = new SerializationInfo(typeof(AgavalException), Substitute.For<IFormatterConverter>());
            Assert.IsNotNull(info);
        }
    }
}
