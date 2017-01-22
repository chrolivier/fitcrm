using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Metadata;

namespace fitcrm.Extensions
{
    public static class AttributeExtensions
    {
        public static string DisplayLabel(this AttributeMetadata attribute)
        {
            return attribute.DisplayName.UserLocalizedLabel.Label;
        }
    }
}
