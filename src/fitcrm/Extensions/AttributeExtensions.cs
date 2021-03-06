﻿using System;
using Microsoft.Xrm.Sdk.Metadata;

namespace fitcrm.Extensions
{
    public static class AttributeExtensions
    {
        public static string DisplayLabel(this AttributeMetadata attribute)
        {
            if (attribute == null) throw new ArgumentNullException(nameof(attribute));
            return attribute.DisplayName?.UserLocalizedLabel?.Label;
        }
    }
}
