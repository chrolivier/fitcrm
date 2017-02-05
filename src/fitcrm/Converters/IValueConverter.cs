using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace fitcrm.Converters
{
    public interface IValueConverter
    {
        object ToCrm(string attributeValue);
        object FromCrm(object entity);
    }
}
