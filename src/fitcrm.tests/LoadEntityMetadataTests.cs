using fitcrm.tests.TestHelpers;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Moq;
using NUnit.Framework;

namespace fitcrm.tests
{

    [TestFixture]
    class LoadEntityMetadataTests
    {
        private Mock<IOrganizationService> _serviceMock;

        [SetUp]
        public void Setup()
        {
            _serviceMock = new Mock<IOrganizationService>();
            CrmTestContext.Instance.OrganizationService = _serviceMock.Object;
        }


        [Test]
        public void Execute_MetadataWasFound_AddsMetadataToMetadataRepository()
        {
            var em = EntityMetadataFactory.CreateEntityMetadata("foo", "Foo");
            var response = new RetrieveEntityResponse
            {
                ["EntityMetadata"] = em
            };
            _serviceMock.Setup(m => m.Execute(It.IsAny<RetrieveEntityRequest>())).Returns(response);

            var sut = new LoadEntityMetadata {LogicalName = "foo"};
            sut.Execute();

            var em2 = CrmTestContext.Instance.MetadataRepository.GetByDisplayName("Foo");
            Assert.That(em2, Is.SameAs(em));

        }

    }
}
