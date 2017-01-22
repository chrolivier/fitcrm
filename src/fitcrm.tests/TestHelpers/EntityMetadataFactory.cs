using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace fitcrm.tests.TestHelpers
{
    class EntityMetadataFactory
    {
        public static EntityMetadata CreateEntityMetadata(string logicalName, string displayName)
        {
            if (string.IsNullOrEmpty(logicalName))
                throw new ArgumentException("Value cannot be null or empty.", nameof(logicalName));
            if (string.IsNullOrEmpty(displayName))
                throw new ArgumentException("Value cannot be null or empty.", nameof(displayName));

            var label = new LocalizedLabel(displayName, 1033);
            var metadata = new EntityMetadata
            {
                LogicalName = logicalName,
                DisplayName = new Label(label, null)
                {
                    UserLocalizedLabel = label
                }
            };

            return metadata;
        }
    }
}
