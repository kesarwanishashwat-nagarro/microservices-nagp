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
    public class AccountController : Controller
    {
        private PostCommand<Account> postCommand;
        private GetAllCommand<Account> getAllCommand;
        private GetStringCommand<Account> getStringCommand;
        private DeleteCommand deleteCommand;
        private PutCommand<Account> putCommand;
        public AccountController(PostCommand<Account> command, GetAllCommand<Account> getAllCommand,
            GetStringCommand<Account> getStringCommand, DeleteCommand deleteCommand, PutCommand<Account> putCommand)
        {
            this.postCommand = command;
            this.getAllCommand = getAllCommand;
            this.getStringCommand = getStringCommand;
            this.deleteCommand = deleteCommand;
            this.putCommand = putCommand;
        }

        [HttpGet("accounts")]
        public IEnumerable<Account> Get()
        {
            IEnumerable<Account> data = getAllCommand.getAll("account/crud");
            return data;
        }

        [HttpDelete("accounts/{accNo}")]
        public string CloseAccount(int accNo)
        {
           return deleteCommand.delete("account/crud/"+ accNo);
        }

        [HttpPost("/accounts/add")]
        public IActionResult PostData([FromBody] Account account)
        {
            string data = postCommand.post(account, "account/crud");
            return Content(data);
        }

        [HttpPut("/accounts/{accNo}")]
        public IActionResult PostData(int accNo, [FromBody] Account account)
        {
            string data = putCommand.put(account, "account/crud/" + accNo);
            return Content(data);
        }

        [HttpGet("/accounts/user/{userId}")]
        public IEnumerable<Account> Get(int userId)
        {
            IEnumerable<Account> data = getAllCommand.getAll("account/linked/"+userId);
            return data;
        }

        [HttpGet("/accounts/transfer/{accNo}/{branchId}")]
        public string ChangeAccountBranch(int accNo, int branchId)
        {
            return getStringCommand.get("account/linked/" + accNo + "/" + branchId);
        }
    }
}
