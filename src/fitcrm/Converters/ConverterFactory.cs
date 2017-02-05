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
        public static IValueConverter CreateConverter(AttributeMetadata attributeMetadata)
        {
            if (attributeMetadata == null) throw new ArgumentNullException(nameof(attributeMetadata));
            switch (attributeMetadata.AttributeType)
            {
                case AttributeTypeCode.String: 
                case AttributeTypeCode.Integer:
                        return new BasicConverter(attributeMetadata);
                // TODO: Do proper exception handling
                default: throw new ArgumentException();
            }
        }
    }
}
