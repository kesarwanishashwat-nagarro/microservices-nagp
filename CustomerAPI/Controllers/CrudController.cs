using CustomerAPI.Models;
using CustomerAPI_Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CustomerAPI.Controllers
{
    [Route("api/crud")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Customer> GetAll()
        {
            return Constants.customers;
        }

        [HttpPost]
        public string Post([FromBody] Customer customer)
        {
            customer.Id = Constants.customers.Max(t => t.Id) + 1;
            Constants.customers.Add(customer);
            return "customer added successfully";
        }

        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Customer customer)
        {
            string response = null;
            Customer cust = Constants.customers.Find(a => a.Id == id);
            if (cust != null)
            {
                cust.Name = customer.Name;
                response = "customer info updated successfully";
            }
            else
            {
                response = "customer not found";
            }
            return response;
        }
    }
}
