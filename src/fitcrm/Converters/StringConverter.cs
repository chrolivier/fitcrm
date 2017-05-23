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
