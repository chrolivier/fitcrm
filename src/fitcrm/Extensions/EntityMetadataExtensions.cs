using System;
using Microsoft.Xrm.Sdk.Metadata;

namespace fitcrm.Extensions
{
    public static class EntityMetadataExtensions
    {
        public static string DisplayLabel(this EntityMetadata metadata)
        {
            if (metadata == null) throw new ArgumentNullException(nameof(metadata));
            return metadata.DisplayName.UserLocalizedLabel.Label;
        }

        

    }
}
