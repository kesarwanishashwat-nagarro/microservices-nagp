using AccountsAPI_Shared;
using AccountsAPI_Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AccountAPI.Controllers
{
    [Route("api/crud")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Account> GetAll()
        {
            return Constants.accounts;
        }

        [HttpPost]
        public string Post([FromBody] Account account)
        {
            Constants.accounts.Add(account);
            return "account created successfully";
        }

        [HttpPut("{number}")]
        public string Put(int number, [FromBody] Account account)
        {
            string response = null;
            Account acc = Constants.accounts.Find(a => a.Number == number);
            if (acc != null)
            {
                acc.type = account.type;
                acc.isClosed = account.isClosed;
                response = "account updated successfully";
            }
            else
            {
                response = "account not found";
            }
            return response;
        }

        [HttpDelete("{number}")]
        public string Delete(int number)
        {
            Account acc = Constants.accounts.Find(a => a.Number == number);
            if (acc != null)
            {
                acc.isClosed = true;
                return "account closed successfully";
            }
            else
            {
                return "account not found";
            }
        }
    }
}
