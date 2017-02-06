using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Metadata;

namespace fitcrm.Converters
{
    public class IntegerConverter : IValueConverter
    {
        public object ToCrm(string attributeValue)
        {
            return int.Parse(attributeValue);
        }

        public object FromCrm(object crmValue)
        {
            return crmValue;
        }
    }
}
