using fitcrm.Extensions;
using Microsoft.Xrm.Sdk;

namespace fitcrm
{
    // 
    public class LoadEntityMetadata
    {
        public string LogicalName { get; set; }
        public string DisplayName { get; private set; }

        private IOrganizationService OrganizationService => CrmTestContext.Instance.OrganizationService;

        public void Execute()
        {
            var metadata = CrmTestContext.Instance.MetadataRepository.GetByLogicalName(LogicalName);
            DisplayName = metadata.DisplayLabel();
        }
    }
}
