using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitcrm.tests.TestHelpers;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Moq;
using NUnit.Framework;

namespace fitcrm.tests
{

    [TestFixture]
    class CreateRecordTests
    {
        private EntityMetadata _metadata;
        private Mock<IOrganizationService> _orgSvcMock;
        private CreateRecord _sut;
        private CrmTestContext _testContext;

        [SetUp]
        public void Setup()
        {
            _metadata = EntityMetadataFactory.CreateEntityMetadata("account", "Account");
            _orgSvcMock = new Mock<IOrganizationService>();
            _testContext = new CrmTestContext {OrganizationService = _orgSvcMock.Object};
            _testContext.MetadataRepository.AddEntityMetadata(_metadata);

            _sut = new CreateRecord("Account");
        }


        [Test]
        public void Execute_SetThrewAnException_DoesNotCallCreate()
        {
            _sut.Reset();
            Exception setException = null;
            Exception executeException = null;
            try
            {
                // Set integer attribute to a string to generate an exception
                _sut.Set("Int Attr", "Foo");
            }
            catch (Exception e)
            {
                setException = e;
            }

            Assert.IsNotNull(setException);

            try
            {
                _sut.Execute();
            }
            catch (Exception e)
            {
                executeException = e;
            }
            Assert.IsNotNull(executeException);
            Assert.AreSame(setException, executeException.InnerException);
            _orgSvcMock.Verify(m => m.Create(It.IsAny<Entity>()), Times.Never);
        }

    }
}
