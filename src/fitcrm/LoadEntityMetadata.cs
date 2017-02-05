using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitcrm.Extensions;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;

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
            var req = new RetrieveEntityRequest
            {
                LogicalName = LogicalName,
                EntityFilters = EntityFilters.Attributes
            };

            var res = (RetrieveEntityResponse)OrganizationService.Execute(req);

            DisplayName = res.EntityMetadata.DisplayLabel();
            CrmTestContext.Instance.MetadataRepository.AddEntityMetadata(res.EntityMetadata);
        }
    }
}
