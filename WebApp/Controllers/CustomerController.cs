using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private PostCommand<Customer> postCommand;
        private GetAllCommand<Customer> getAllCommand;
        private PutCommand<Customer> putCommand;
        public CustomerController(PostCommand<Customer> command, GetAllCommand<Customer> getCommand,
            PutCommand<Customer> putCommand)
        {
            this.postCommand = command;
            this.putCommand = putCommand;
            this.getAllCommand = getCommand;
        }

        [HttpGet("/customers")]
        public IEnumerable<Customer> GetAll()
        {
            IEnumerable<Customer> data = getAllCommand.getAll("customer/crud");
            return data;
        }

        [HttpPost("/customers/add")]
        public IActionResult PostData([FromBody] Customer customer)
        {
            string data = postCommand.post(customer, "customer/crud");
            return Content(data);
        }

        [HttpPut("/customers/{id}")]
        public IActionResult UpdateData(int id, [FromBody] Customer customer)
        {
            string data = putCommand.put(customer, "customer/crud/" + id);
            return Content(data);
        }
    }
}
