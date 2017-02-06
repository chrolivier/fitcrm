using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using fitcrm.Repositories;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
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

        public CrmTestContext()
        {
            _instance = this;
        }

        public void ConnectToCrm(string connectionString)
        {
            _svcClient?.Dispose();

            _svcClient = new CrmServiceClient(connectionString);
            _organizationService = (IOrganizationService) _svcClient.OrganizationWebProxyClient ?? (IOrganizationService)_svcClient.OrganizationServiceProxy;
            var req = new WhoAmIRequest();
            // TODO: Log connect results and errors
            _organizationService.Execute(req);
        }

        public void ConnectToServerWithUserDomainPassword(string uri, string username, string domain, string password)
        {
            var cred = new ClientCredentials();
            cred.Windows.ClientCredential.Domain = domain;
            cred.Windows.ClientCredential.UserName = username;
            cred.Windows.ClientCredential.Password = password;
            _organizationService = new OrganizationServiceProxy(new Uri(uri), null, cred, null);
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
