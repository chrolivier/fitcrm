using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;

namespace fitcrm
{
    public class CreateRecord
    {
        private readonly EntityMetadata _entityMetadata;
        private Entity _entity;
        private EntityAttributeMapper _mapper;
        private readonly CrmTestContext _testContext;
        private Exception _setException;

        public CreateRecord(string entityDisplayName)
        {
            if (entityDisplayName == null) throw new ArgumentNullException(nameof(entityDisplayName));
            _testContext = CrmTestContext.Instance;
            _entityMetadata = _testContext.MetadataRepository.GetByDisplayName(entityDisplayName);
        }

        public void Reset()
        {
            _entity = new Entity(_entityMetadata.LogicalName);
            _mapper = new EntityAttributeMapper(_entityMetadata, _entity);
            _setException = null;
        }

        public void Set(string attributeDisplayName, string attributeValue)
        {
            try
            {
                _mapper.SetValue(attributeDisplayName, attributeValue);
            }
            catch (Exception e)
            {
                _setException = e;
                throw;
            }
        }

        public object Get(string attributeDisplayName)
        {
            return _mapper.GetValue(attributeDisplayName);
        }

        public void Execute()
        {
            // Don't try to create if setting a value raised an exception
            if (_setException != null)
            {
                throw new InvalidOperationException("Create not executed due to exception while setting attribute values.", _setException);
            }

            var id = _testContext.OrganizationService.Create(_entity);
            _entity = _testContext.OrganizationService.Retrieve(_entityMetadata.LogicalName, id, new ColumnSet(true));
            _mapper = new EntityAttributeMapper(_entityMetadata, _entity);
        }
    }
}
