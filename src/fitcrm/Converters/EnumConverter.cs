using System;
using System.Linq;
using fitcrm.Extensions;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace fitcrm.Converters
{
    public class EnumConverter : IValueConverter
    {
        private readonly EnumAttributeMetadata _attributeMetadata;

        public EnumConverter(AttributeMetadata attributeMetadata)
        {
            if (attributeMetadata == null) throw new ArgumentException(nameof(attributeMetadata));
            _attributeMetadata = (EnumAttributeMetadata)attributeMetadata;
        }

        public object FromCrm(object crmValue)
        {
            var optionValue = (OptionSetValue) crmValue;
            var option = _attributeMetadata.OptionSet.Options.First(o => o.Value == optionValue.Value);
            return option.Label.UserLocalizedLabel.Label;
        }

        public object ToCrm(string attributeValue)
        {
            var option = _attributeMetadata.OptionSet.Options.FirstOrDefault(o => o.DisplayLabel() == attributeValue);

            if (option == null)
                throw new InvalidOperationException($"{attributeValue} is not a valid value");

            if (option.Value != null)
                return new OptionSetValue(option.Value.Value);
            return null;
        }
    }
}
