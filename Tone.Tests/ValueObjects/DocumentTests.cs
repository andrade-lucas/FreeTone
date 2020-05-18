using Tone.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tone.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        private Document _document;

        [TestMethod]
        [TestCategory("ValueObjects")]
        public void ShouldReturnValidWhenDocumentIsJustNumbersAndIsValid()
        {
            _document = new Document("67572663001");
            Assert.AreEqual(true, _document.IsValid);
        }

        [TestMethod]
        [TestCategory("ValueObjects")]
        public void ShouldReturnValidWhenDocumentHasSpecialCaracteresAndIsValid()
        {
            _document = new Document("260.611.100-14");
            Assert.AreEqual(true, _document.IsValid);
        }

        [TestMethod]
        [TestCategory("ValueObjects")]
        public void ShouldReturnInvalidWhenDocumentIsInvalid()
        {
            _document = new Document("12345678912");
            Assert.AreNotEqual(true, _document.IsValid);
        }

        [TestMethod]
        [TestCategory("ValueObjects")]
        public void ShouldReturnInvalidWhenDocumentNumbersAreEqual()
        {
            _document = new Document("00000000000");
            Assert.AreNotEqual(true, _document.IsValid);
        }
    }
}