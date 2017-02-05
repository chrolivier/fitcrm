using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace fitcrm.Converters
{
    class BasicConverter : IValueConverter
    {
        private readonly StringAttributeMetadata _attributeMetadata;

        public BasicConverter(AttributeMetadata attributeMetadata)
        {
            _attributeMetadata = (StringAttributeMetadata)attributeMetadata;
        }

        public object ToCrm(string attributeValue)
        {
            return attributeValue;
        }

        public object FromCrm(object entity)
        {
            return entity;
        }
    }
}
