using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitcrm.Exceptions;
using Microsoft.Xrm.Sdk.Metadata;

namespace fitcrm.Repositories
{
    public class MetadataRepository
    {
        private readonly EntityMetadataCollection _items = new EntityMetadataCollection();

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
    }
}
