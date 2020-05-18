using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tone.Domain.ValueObjects;

namespace Tone.Tests.ValueObjects
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        [TestCategory("ValueObjects")]
        public void ShouldReturnValidWhenNameIsValid()
        {
            Name name = new Name("FirstName", "LastName");
            Assert.AreEqual(0, name.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("ValueObjects")]
        public void ShouldReturnInvalidWhenNameHasLessThan2Caracteres()
        {
            Name name = new Name("A", "");
            Assert.AreNotEqual(0, name.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("ValueObjects")]
        public void ShouldReturnInvalidWhenNameHasMoreThan40Caracteres()
        {
            Name name = new Name("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "");
            Assert.AreEqual(false, name.IsValid);
        }

        [TestMethod]
        [TestCategory("ValueObjects")]
        public void ShouldReturnInvalidWhenNameIsNull()
        {
            Name name = new Name(null, null);
            Assert.AreNotEqual(true, name.IsValid);
        }
    }
}