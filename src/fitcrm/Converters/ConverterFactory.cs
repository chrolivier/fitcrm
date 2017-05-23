using System;
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
                case AttributeTypeCode.Picklist:
                case AttributeTypeCode.State:
                case AttributeTypeCode.Status:
                    return new EnumConverter(attributeMetadata);
                case AttributeTypeCode.Boolean: return new BooleanConverter(attributeMetadata);
                case AttributeTypeCode.Money: return new MoneyConverter(attributeDescriptor);
                        
                // TODO: Do proper exception handling
                default: throw new ArgumentException();
            }
        }
    }
}
