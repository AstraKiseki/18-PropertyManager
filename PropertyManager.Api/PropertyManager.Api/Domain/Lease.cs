using PropertyManager.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManager.Api.Domain
{
    public enum RentFrequencies
    {
        Daily = 1,
        Weekly = 2,
        Monthly = 3,
        Quarterly = 4,
        BiAnnually = 5,
        Annually = 6
    }

    public class Lease
    {
        public int LeaseId { get; set; }
        public int TenantId { get; set; }
        public int PropertyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal RentAmount { get; set; }
        public RentFrequencies RentFrequency { get; set; }

        public virtual Property Property { get; set; }
        public virtual Tenant Tenant { get; set; }

        public void Update(LeaseModel modelLease)
        {
            TenantId = modelLease.TenantId;
            PropertyId = modelLease.PropertyId;
            StartDate = modelLease.StartDate;
            EndDate = modelLease.EndDate;
            RentAmount = modelLease.RentAmount;
            RentFrequency = modelLease.RentFrequency;
        }

        static void Main(string[] args)
        {
            var property = new Property();
            var tenant = new Tenant();

            var lease = new Lease();

            lease.Property = property;
            lease.Tenant = tenant;

            Console.WriteLine(property.Leases.Count == 1);
            Console.WriteLine(tenant.Leases.Count == 1);

            List<string> tenantNames = new List<string>();

            foreach (var l in property.Leases)
            {
                tenantNames.Add(lease.Tenant.FirstName + " " + lease.Tenant.LastName);
            }
        }
    }

}

