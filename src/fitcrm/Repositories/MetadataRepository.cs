using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitcrm.Exceptions;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Tooling.Connector;

namespace fitcrm.Repositories
{
    public class MetadataRepository
    {
        private readonly IOrganizationService _svcClient;
        private readonly EntityMetadataCollection _items = new EntityMetadataCollection();

        public MetadataRepository()
        {
            
        }
        public MetadataRepository(IOrganizationService svcClient)
        {
            if (svcClient == null) throw new ArgumentNullException(nameof(svcClient));
            _svcClient = svcClient;
        }

        public void AddEntityMetadata(EntityMetadata metadata)
        {
            if (!_items.Contains(metadata))
                _items.Add(metadata);
        }

        public EntityMetadata GetByDisplayName(string displayName)
        {
            if (string.IsNullOrWhiteSpace(displayName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(displayName));
            var metadata = _items.FirstOrDefault(md => md.DisplayName.UserLocalizedLabel.Label == displayName);
            if (metadata == null)
                throw new MetadataNotFoundException($"Entity metadata for entity with display name {displayName} was not found.");
            return metadata;
        }

        public EntityMetadata GetByLogicalName(string logicalName)
        {
            if (string.IsNullOrWhiteSpace(logicalName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(logicalName));

            var metadata = _items.FirstOrDefault(md => md.LogicalName == logicalName);
            if (metadata == null && _svcClient != null)
            {
                var req = new RetrieveEntityRequest
                {
                    LogicalName = logicalName,
                    EntityFilters = EntityFilters.Attributes
                };

                var res = (RetrieveEntityResponse)_svcClient.Execute(req);
                if (res.EntityMetadata != null)
                {
                    metadata = res.EntityMetadata;
                    _items.Add(metadata);
                }
            }
            return metadata;
        }
    }
}
