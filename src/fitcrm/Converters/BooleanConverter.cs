﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitcrm.Extensions;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace fitcrm.Converters
{
    public class BooleanConverter : IValueConverter
    {
        private readonly BooleanAttributeMetadata _attributeMetadata;
        private OptionMetadata _trueOption;
        private OptionMetadata _falseOption;

        public BooleanConverter(AttributeMetadata attributeMetadata)
        {
            if (attributeMetadata == null) throw new ArgumentNullException(nameof(attributeMetadata));
            _attributeMetadata = (BooleanAttributeMetadata)attributeMetadata;
            _trueOption = _attributeMetadata.OptionSet.TrueOption;
            _falseOption = _attributeMetadata.OptionSet.FalseOption;
        }

        public object ToCrm(string attributeValue)
        {
            if (attributeValue == _attributeMetadata.OptionSet.TrueOption.DisplayLabel())
                return true;
                //return new OptionSetValue(_trueOption.Value.Value);

            if (attributeValue == _attributeMetadata.OptionSet.FalseOption.DisplayLabel())
                return false;
                //return new OptionSetValue(_falseOption.Value.Value);

            throw new InvalidOperationException($"{attributeValue} is not a valid value.");
        }

        public object FromCrm(object crmValue)
        {
            var value = (bool) crmValue;

            return value ? _trueOption.DisplayLabel() : _falseOption.DisplayLabel();
        }
    }
}