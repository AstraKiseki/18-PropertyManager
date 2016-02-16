using PropertyManager.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManager.Api.Domain
{
    public class Property
    {
        public int PropertyId { get; set; }
        public string UserId { get; set; }

        public int? AddressId { get; set; }
        public string PropertyName { get; set; }
        public int? SquareFeet { get; set; }
        public int? NumberOfBedrooms { get; set; }
        public float? NumberOfBathrooms { get; set; }
        public int? NumberOfVehicles { get; set; }
        public bool HasOutdoorSpace { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Lease> Leases { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
        public virtual PropertyManagerUser User { get; set; }

        public void Update(PropertyModel modelProperty)
        {
            PropertyId = modelProperty.PropertyId;
            AddressId = modelProperty.AddressId;
            PropertyName = modelProperty.PropertyName;
            SquareFeet = modelProperty.SquareFeet;
            NumberOfBedrooms = modelProperty.NumberOfBedrooms;
            NumberOfBathrooms = modelProperty.NumberOfBathrooms;
            NumberOfVehicles = modelProperty.NumberOfVehicles;
            HasOutdoorSpace = modelProperty.HasOutdoorSpace;
        }

        static void Main(string[] args)
        {
            // Property p = db.Properties.First();
            Property property = new Property();

            string address1 = property.Address.Address1;

        }
    }
}