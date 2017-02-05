using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitcrm.Converters;
using fitcrm.Extensions;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace fitcrm
{
    public class EntityAttributeMapper
    {
        private readonly EntityMetadata _entityMetadata;
        private readonly Entity _entity;

        public EntityAttributeMapper(EntityMetadata entityMetadata, Entity entity)
        {
            if (entityMetadata == null) throw new ArgumentNullException(nameof(entityMetadata));
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _entityMetadata = entityMetadata;
            _entity = entity;
        }

        public void SetValue(string attributeDisplayName, string attributeValue)
        {
            // Setting something to "--" doesn't set any value on CRM. Important for testing scenarios where a value should not be set instead of setting it to a blank field.
            if (attributeValue == "--") return;

            var attrMetadata = GetAttributeMetadata(attributeDisplayName);

            var converter = ConverterFactory.CreateConverter(attrMetadata);
            _entity[attrMetadata.LogicalName] = converter.ToCrm(attributeValue);
            
        }

        private AttributeMetadata GetAttributeMetadata(string attributeDisplayName)
        {
            var attrMetadata = _entityMetadata.Attributes.FirstOrDefault(a => a.DisplayLabel() == attributeDisplayName);
            // TODO: Create proper exception
            if (attrMetadata == null)
                throw new InvalidOperationException(
                    $"An attribute \"{attributeDisplayName}\" does not exist on entity {_entityMetadata.DisplayLabel()}");
            return attrMetadata;
        }

        public object GetValue(string attributeDisplayName)
        {
            var attrMetadata = GetAttributeMetadata(attributeDisplayName);
            // Return "--" if no value was present for the attribute
            if (!_entity.Contains(attrMetadata.LogicalName))
                return "--";

            var converter = ConverterFactory.CreateConverter(attrMetadata);
            return converter.FromCrm(_entity[attrMetadata.LogicalName]);
        }
    }
}
