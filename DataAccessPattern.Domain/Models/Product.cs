using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessPattern.Domain.Models
{
    public class Product
    {
        public Guid ProductId { get; private set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Product()
        {
            ProductId = Guid.NewGuid();
        }
    }
}
