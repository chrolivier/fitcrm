using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitcrm.Converters
{
    public class DateTimeConverter : IValueConverter
    {
        private readonly AttributeDescriptor _descriptor;

        public DateTimeConverter(AttributeDescriptor descriptor)
        {
            if (descriptor == null) throw new ArgumentNullException(nameof(descriptor));
            _descriptor = descriptor;
        }

        public object ToCrm(string attributeValue)
        {
            DateTime result;
            if (_descriptor.Format != null)
            {
                result = DateTime.ParseExact(attributeValue, _descriptor.Format, CultureInfo.InvariantCulture);
            }
            else
            {
                result = DateTime.Parse(attributeValue);
            }

            return result;
        }

        public object FromCrm(object crmValue)
        {
            var dateValue = ((DateTime) crmValue).ToLocalTime();

            if (_descriptor.Format != null)
                return dateValue.ToString(_descriptor.Format);

            return dateValue;
        }
    }
}
