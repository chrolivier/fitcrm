using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitcrm.Converters;
using fitcrm.tests.TestHelpers;
using Microsoft.Xrm.Sdk;
using NUnit.Framework;
using Microsoft.Xrm.Sdk.Metadata;

namespace fitcrm.tests.Converters
{
    [TestFixture]
    public class EnumConverterTests
    {
        private EnumAttributeMetadata _attrMetadata;
        private EntityMetadata _metaData;
        private EnumConverter _sut;

        [SetUp]
        public void SetUp()
        {
            _metaData = EntityMetadataFactory.CreateEntityMetadata("account", "Account");
            _sut = new EnumConverter(_metaData.Attributes.First(a => a.LogicalName == "picklistattr"));
        }

        [Test]
        [TestCase(1, "Option1")]
        [TestCase(2, "Option2")]
        [TestCase(3, "Option3")]
        public void FromCrm_Always_ReturnsOptionDisplayLabel(int value, string expectedLabel)
        {
            var result = _sut.FromCrm(new OptionSetValue(value));
            Assert.That(result, Is.EqualTo(expectedLabel));
        }

        [Test]
        [TestCase("Option1", 1)]
        [TestCase("Option2", 2)]
        [TestCase("Option3", 3)]
        public void ToCrm_ValidLabel_ReturnsOptionSet(string text, int expectedValue)
        {
            var result = _sut.ToCrm(text);
            Assert.That(result, Is.EqualTo(new OptionSetValue(expectedValue)));
        }

        [Test]
        public void ToCrm_InvalidLabel_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _sut.ToCrm("Foo"));
        }

    }

}
