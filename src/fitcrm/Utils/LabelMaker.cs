using Microsoft.Xrm.Sdk;

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
