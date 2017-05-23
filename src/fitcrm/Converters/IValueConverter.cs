namespace fitcrm.Converters
{
    public interface IValueConverter
    {
        object ToCrm(string attributeValue);
        object FromCrm(object crmValue);
    }
}
