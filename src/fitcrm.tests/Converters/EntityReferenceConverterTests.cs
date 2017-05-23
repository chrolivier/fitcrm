using System;
using fitcrm.Converters;
using Microsoft.Xrm.Sdk;
using NUnit.Framework;

namespace fitcrm.tests.Converters
{
    [TestFixture]
    public class EntityReferenceConverterTests
    {

        [Test]
        public void FromCrm_MemberIsId_ReturnsGuid()
        {
            var id = Guid.NewGuid();
            var er = new EntityReference("foo", id);
            var ad = new AttributeDescriptor("Name", "Id", null);
            var sut = new EntityReferenceConverter(ad);

            Assert.AreEqual(id, sut.FromCrm(er));
        }

        [Test]
        public void FromCrm_MemberIsType_ReturnsLogicalName()
        {
            var er = new EntityReference("Duck", Guid.NewGuid());
            var ad = new AttributeDescriptor("Name", "Type", null);
            var sut = new EntityReferenceConverter(ad);

            Assert.AreEqual("Duck", sut.FromCrm(er));
        }

        [Test]
        public void FromCrm_NoAttributeDescriptorAndNameHasValue_ReturnsName()
        {
            var er = new EntityReference("Duck", new Guid())
            {
                Name = "Quacky"
            };

            var sut = new EntityReferenceConverter();
            Assert.AreEqual("Quacky", sut.FromCrm(er));
        }

        [Test]
        public void FromCrm_NoAttributeDescriptorNameIsNull_RetrievesAndReturnsRecordPrimaryAttribute()
        {
            // TODO: Go on here
            // Retrieve entity reference's metadata from MetadataRepository and then retrieve
            // the record's primary attribute from CRM        
        }

        [Test]
        public void FromCrm_MemberIsNullAndNameHasValue_ReturnsName()
        {
            var er = new EntityReference("Duck", new Guid())
            {
                Name = "Quacky"
            };

            var ad = new AttributeDescriptor("Duck", null, null);
            var sut = new EntityReferenceConverter(ad);
            Assert.AreEqual("Quacky", sut.FromCrm(er));
        }
    }
}
