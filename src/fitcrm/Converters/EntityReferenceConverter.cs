using System;
using Microsoft.Xrm.Sdk;

namespace fitcrm.Converters
{
    public class EntityReferenceConverter : IValueConverter
    {
        private readonly AttributeDescriptor _attributeDescriptor;

        public EntityReferenceConverter(AttributeDescriptor attributeDescriptor)
        {
            _attributeDescriptor = attributeDescriptor;
        }

        public EntityReferenceConverter()
        {
        }

        public object ToCrm(string attributeValue)
        {
            //TODO: Implement
            throw new NotImplementedException();
        }

        public object FromCrm(object crmValue)
        {
            var entityRef = (EntityReference) crmValue;
            if (_attributeDescriptor != null)
            {
                switch (_attributeDescriptor.Member)
                {
                    case "Id":
                        return entityRef.Id;
                    case "Type":
                        return entityRef.LogicalName;
                }
            }
            return entityRef.Name;
        }
    }
}
