using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace fitcrm.Converters
{
    class StringConverter : IValueConverter
    {

        public object ToCrm(string attributeValue)
        {
            return attributeValue;
        }

        public object FromCrm(object crmValue)
        {
            return crmValue;
        }
    }
}
