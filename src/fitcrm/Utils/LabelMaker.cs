using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitcrm.Utils
{
    public static class LabelMaker
    {
        public static Label MakeLabel(string labelText)
        {
            var ll = new LocalizedLabel(labelText, 1033);
            var label = new Label(ll, null)
            {
                UserLocalizedLabel = ll
            };
            return label;
        }
    }
}
