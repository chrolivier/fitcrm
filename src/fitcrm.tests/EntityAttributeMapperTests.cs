using fitcrm.tests.TestHelpers;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using NUnit.Framework;

namespace fitcrm.tests
{

    [TestFixture]
    public class EntityAttributeMapperTests
    {
        private EntityMetadata _metadata;
        private Entity _entity;
        private EntityAttributeMapper _sut;

        [SetUp]
        public void Setup()
        {
            _metadata = EntityMetadataFactory.CreateEntityMetadata("account", "Account");
            _entity = new Entity("account");
            _sut = new EntityAttributeMapper(_metadata, _entity);
        }

        [Test]
        public void Set_ValueIsDoubleDash_NoValueIsSet()
        {
            _sut.SetValue("String Attr", "--");
            Assert.That(_entity.Contains("stringattr"), Is.False);
        }

        [Test]
        public void GetValue_AttributeNotSetOnEntity_ReturnsDoubleDash()
        {
            // No value has been set for String Attr
            Assert.That(_sut.GetValue("String Attr"), Is.EqualTo("--"));
        }


    }
}
