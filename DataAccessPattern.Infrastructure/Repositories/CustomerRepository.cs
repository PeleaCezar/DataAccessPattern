using DataAccessPattern.Domain.Models;
using DataAccessPattern.Infrastructure.Lazy.Ghosts;
using DataAccessPattern.Infrastructure.Lazy.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessPattern.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(ShoppingContext context) : base(context)
        {
        }

        public override Customer Get(Guid id)
        {
            var customerId = context.Customers
                .Where(c => c.CustomerId == id)
                .Select(c => c.CustomerId)
                .Single();

            return new GhostCustomer(() => base.Get(id))
            {
                CustomerId = customerId
            };
        }

        public override IEnumerable<Customer> All()
        {
            return base.All().Select(MapToProxy);
        }

        public override Customer Update(Customer entity)
        {
            var customer = context.Customers
                .Single(p => p.CustomerId == entity.CustomerId);

            customer.Name = entity.Name;
            customer.City = entity.City;
            customer.PostalCode = entity.PostalCode;
            customer.ShippingAddress = entity.ShippingAddress;
            customer.Country = entity.Country;


            return base.Update(customer);
        }

        private CustomerProxy MapToProxy(Customer customer)
        {
            return new CustomerProxy
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                ShippingAddress = customer.ShippingAddress,
                City = customer.City,
                PostalCode =customer.PostalCode,
                Country = customer.Country

            };
        }
    }
}
