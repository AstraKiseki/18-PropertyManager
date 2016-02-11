using PropertyManager.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManager.Api.Domain
{
    public class Tenant
    {
        public int TenantId { get; set; }
        public int? AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string EmailAddress { get; set; }

        public Address Address { get; set; }

        public void Update(TenantModel modelTenant)
        {
            TenantId = modelTenant.TenantId;
            AddressId = modelTenant.AddressId;
            FirstName = modelTenant.FirstName;
            LastName = modelTenant.LastName;
            Telephone = modelTenant.Telephone;
            EmailAddress = modelTenant.EmailAddress;
        }

        public virtual ICollection<Lease> Leases { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}