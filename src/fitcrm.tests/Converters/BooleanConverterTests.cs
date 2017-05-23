using System;
using System.Linq;
using fitcrm.Converters;
using fitcrm.Extensions;
using fitcrm.tests.TestHelpers;
using NUnit.Framework;

namespace fitcrm.tests.Converters
{
    public class BooleanConverterTests
    {
        private BooleanConverter _sut;

        [SetUp]
        public void SetUp()
        {
            var entityMetadata = EntityMetadataFactory.CreateEntityMetadata("account", "Account");
            _sut = new BooleanConverter(entityMetadata.Attributes.First(a => a.DisplayLabel() == "Boolean Attr"));
        }

        [Test]
        [TestCase("Yes", true)]
        [TestCase("No", false)]
        public void ToCrm_ValidLabel_ReturnCorrectValue(string text, bool expectedValue)
        {
            Assert.That(_sut.ToCrm(text), Is.EqualTo(expectedValue));
        }

        [Test]
        public void ToCrm_InvalidLabel_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _sut.ToCrm("foo"));
        }

        [Test]
        [TestCase(true, "Yes")]
        [TestCase(false, "No")]
        public void FromCrm_Always_ReturnsOptionsLabel(bool value, string expectedValue)
        {
            Assert.That(_sut.FromCrm(value), Is.EqualTo(expectedValue));

        }

    }
}
