using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitcrm.Repositories;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;

namespace fitcrm
{
    public class CrmTestContext : IDisposable
    {
        private static CrmTestContext _instance;
        public static CrmTestContext Instance
        {
            get { return _instance ?? (_instance = new CrmTestContext()); }
            set { _instance = value; }
        }

        private CrmServiceClient _svcClient;
        private IOrganizationService _organizationService;

        public void ConnectToCrm(string connectionString)
        {
            _svcClient?.Dispose();

            _svcClient = new CrmServiceClient(connectionString);
            _organizationService = _svcClient;
            var req = new WhoAmIRequest();
            // TODO: Log connect results and errors
            _svcClient.Execute(req);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                _svcClient?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public IOrganizationService OrganizationService
        {
            get { return _organizationService; }
            set { _organizationService = value; }
        }

        public MetadataRepository MetadataRepository { get; } = new MetadataRepository();
    }
}
