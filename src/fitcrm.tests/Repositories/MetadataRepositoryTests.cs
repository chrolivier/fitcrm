using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitcrm.Exceptions;
using fitcrm.Repositories;
using fitcrm.tests.TestHelpers;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using NUnit.Framework;

namespace fitcrm.tests.Repositories
{

    [TestFixture]
    class MetadataRepositoryTests
    {
        private MetadataRepository _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new MetadataRepository();
        }


        [Test]
        public void GetByDisplayName_MetadataExists_ReturnsMetadataWithMatchingUserLocalizedLabel()
        {
            var md1 = EntityMetadataFactory.CreateEntityMetadata("entity1", "Entity1");
            var md2 = EntityMetadataFactory.CreateEntityMetadata("entity2", "Entity2");

            _sut.AddEntityMetadata(md1);
            _sut.AddEntityMetadata(md2);

            Assert.That(_sut.GetByDisplayName("Entity2"), Is.SameAs(md2));
            Assert.That(_sut.GetByDisplayName("Entity1"), Is.SameAs(md1));
        }

        [Test]
        public void GetByDisplayName_MetadataDoesntExist_ThrowsException()
        {
            Assert.Throws<MetadataNotFoundException>(() => _sut.GetByDisplayName("foo"));
        }


    }
}
