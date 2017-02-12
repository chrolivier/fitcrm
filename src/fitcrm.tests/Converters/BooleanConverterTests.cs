using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitcrm.Converters;
using fitcrm.Extensions;
using fitcrm.tests.TestHelpers;
using Microsoft.Xrm.Sdk;
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
        [TestCase("Yes", 1)]
        [TestCase("No", 2)]
        public void ToCrm_ValidLabel_ReturnCorrectValue(string text, int expectedValue)
        {
            Assert.That(_sut.ToCrm(text), Is.EqualTo(new OptionSetValue(expectedValue)));
        }

        [Test]
        public void ToCrm_InvalidLabel_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _sut.ToCrm("foo"));
        }

        [Test]
        [TestCase(1, "Yes")]
        [TestCase(2, "No")]
        public void FromCrm_Always_ReturnsOptionsLabel(int value, string expectedValue)
        {
            Assert.That(_sut.FromCrm(new OptionSetValue(value)), Is.EqualTo(expectedValue));

        }

    }
}
