using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Metadata;

namespace fitcrm.Converters
{
    static class ConverterFactory
    {
        public static IValueConverter CreateConverter(AttributeMetadata attributeMetadata, AttributeDescriptor attributeDescriptor)
        {
            if (attributeMetadata == null) throw new ArgumentNullException(nameof(attributeMetadata));
            switch (attributeMetadata.AttributeType)
            {
                case AttributeTypeCode.String: return new StringConverter();
                case AttributeTypeCode.Integer: return new IntegerConverter();
                case AttributeTypeCode.DateTime: return new DateTimeConverter(attributeDescriptor);
                        
                // TODO: Do proper exception handling
                default: throw new ArgumentException();
            }
        }
    }
}
