using Tone.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tone.Tests.ValueObjects
{
    [TestClass]
    public class EmailTests
    {
        private Email _email;

        [TestMethod]
        public void ShouldReturnValidWhenEmailAddressIsValid()
        {
            _email = new Email("test@test.com");
            Assert.AreEqual(true, _email.IsValid);
        }

        [TestMethod]
        public void ShouldReturnInvalidWhenEmailAddressIsInvalid()
        {
            _email = new Email("test");
            Assert.AreNotEqual(true, _email.IsValid);
        }
    }
}