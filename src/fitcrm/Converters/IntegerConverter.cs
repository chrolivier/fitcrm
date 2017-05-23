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
