using System;
using Microsoft.Xrm.Sdk.Metadata;

namespace fitcrm.Extensions
{
    public static class OptionMetadataExtensions
    {
        public static string DisplayLabel(this OptionMetadata optionMetadata)
        {
            if (optionMetadata == null) throw new ArgumentNullException(nameof(optionMetadata));
            return optionMetadata.Label?.UserLocalizedLabel?.Label;
        }
    }
}
