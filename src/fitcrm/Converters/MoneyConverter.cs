using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace fitcrm.Converters
{
    public class MoneyConverter : IValueConverter
    {
        private readonly AttributeDescriptor _attributeDescriptor;

        public MoneyConverter(AttributeDescriptor attributeDescriptor)
        {
            _attributeDescriptor = attributeDescriptor;
        }

        public object ToCrm(string attributeValue)
        {
            var value = decimal.Parse(attributeValue);
            return new Money(value);
        }

        public object FromCrm(object crmValue)
        {
            var moneyValue = (Money) crmValue;


            return moneyValue.Value;
        }
    }
}
