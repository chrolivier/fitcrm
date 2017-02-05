using System;
using System.Collections.Generic;
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

            var t = metadata.GetType();
            var p = t.GetProperty("Attributes");
            p.SetValue(metadata, CreateAttributes());

            return metadata;
        }

        private static AttributeMetadata[] CreateAttributes()
        {
            var attrs = new List<AttributeMetadata>
            {
                CreateAttributeMetadata<StringAttributeMetadata>("stringattr", "String Attr"),
                CreateAttributeMetadata<IntegerAttributeMetadata>("intattr", "Int Attr"),
                CreateAttributeMetadata<DateTimeAttributeMetadata>("dateattr", "Date Attr")
            };

            return attrs.ToArray();
        }

        private static T CreateAttributeMetadata<T>(string logicalName, string displayLabel) where T : AttributeMetadata, new()
        {
            var label = new LocalizedLabel(displayLabel, 1033);
            var attr = new T()
            {
                LogicalName = logicalName,
                DisplayName = new Label(label, null)
                {
                    UserLocalizedLabel = label
                }
            };
            return attr;
        }
    }
}
