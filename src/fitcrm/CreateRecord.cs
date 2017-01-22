using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitcrm.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace fitcrm
{
    public class CreateRecord
    {
        private readonly EntityMetadata _entityMetadata;
        private Entity _entity;

        public CreateRecord(string entityDisplayName)
        {
            if (entityDisplayName == null) throw new ArgumentNullException(nameof(entityDisplayName));
            _entityMetadata = CrmTestContext.Instance.MetadataRepository.GetByDisplayName(entityDisplayName);
        }

        public void Reset()
        {
            _entity = new Entity(_entityMetadata.LogicalName);
        }

        public void Set(string attributeDisplayName, object attributeValue)
        {
            
        }
    }
}
