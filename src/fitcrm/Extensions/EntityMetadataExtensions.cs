using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
