using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitcrm.Extensions;
using fitcrm.Repositories;
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
        }

        public void Set(string attributeDisplayName, string attributeValue)
        {
            _mapper.SetValue(attributeDisplayName, attributeValue);
        }

        public object Get(string attributeDisplayName)
        {
            return _mapper.GetValue(attributeDisplayName);
        }

        public void Execute()
        {
            var id = _testContext.OrganizationService.Create(_entity);
            _entity = _testContext.OrganizationService.Retrieve(_entityMetadata.LogicalName, id, new ColumnSet(true));
            _mapper = new EntityAttributeMapper(_entityMetadata, _entity);
        }
    }
}
