using DataAccessPattern.Domain.Models;
using DataAccessPattern.Infrastructure;
using DataAccessPattern.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessPatern.Controllers
{
    public class CustomerController : Controller
    {

        private readonly IRepository<Customer> customerRepository;

        public CustomerController(IRepository<Customer> customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IActionResult Index(Guid? id)
        {
            if(id == null)
            {
                var customers = customerRepository.All();

                return View(customers);
            }
            else
            {
                var customer = customerRepository.Get(id.Value);

                return View(new[] { customer });
            }
        }
    }
}
