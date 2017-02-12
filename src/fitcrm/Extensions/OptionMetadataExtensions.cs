using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
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
