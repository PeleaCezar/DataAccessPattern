using DataAccessPattern.Domain.Models;
using DataAccessPattern.Infrastructure.Lazy.Proxies;
using System;

namespace DataAccessPattern.Infrastructure.Lazy.Ghosts
{
    public class GhostCustomer : CustomerProxy
    {
        private LoadStatus status;
        private readonly Func<Customer> load;

        public bool isGhost => status == LoadStatus.GHOST;
        public bool isLoaded => status == LoadStatus.LOADED;

        public GhostCustomer(Func<Customer> load) : base()
        {
            this.load = load;
            status = LoadStatus.GHOST;
        }

        public override string Name 
        {
            get
            {
                Load();
                return base.Name;
            }
            set
            {
                Load();
                base.Name = value;
            }
        }

        public void Load()
        {
            if (isGhost)
            {
                status = LoadStatus.LOADING;
                var customer = load();
                base.Name = customer.Name;
                base.ShippingAddress = customer.ShippingAddress;
                base.City = customer.City;
                base.PostalCode = customer.PostalCode;
                base.Country = customer.Country;

                status = LoadStatus.LOADED;
            }
        }
    }

    enum LoadStatus { GHOST, LOADING, LOADED };
}
