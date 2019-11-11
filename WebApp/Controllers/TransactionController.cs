using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class TransactionController : Controller
    {
        private PostCommand<Transaction> postCommand;
        private GetAllCommand<Transaction> getAllCommand;
        private GetStringCommand<Transaction> getStringCommand;
        public TransactionController(PostCommand<Transaction> command, GetAllCommand<Transaction> getCommand,
            GetStringCommand<Transaction> getStringCommand)
        {
            this.postCommand = command;
            this.getAllCommand = getCommand;
            this.getStringCommand = getStringCommand;
        }

        [HttpGet("/transaction")]
        public IEnumerable<Transaction> GetAll()
        {
            IEnumerable<Transaction> data = getAllCommand.getAll("transaction/crud");
            return data;
        }

        [HttpGet("/transaction/account/{accNo}")]
        public IEnumerable<Transaction> GetAllbyAccountNumber(int accNo)
        {
            IEnumerable<Transaction> data = getAllCommand.getAll("transaction/crud/" + accNo);
            return data;
        }

        [HttpPost("/transaction/add")]
        public IActionResult PostData([FromBody] Transaction transaction)
        {
            string data = postCommand.post(transaction, "transaction/crud");
            if (data == "successful")
            {
                data = performAccountUpdate(transaction.srcAccountNumber, transaction.destAccountNumber.HasValue ? transaction.destAccountNumber.Value : 0, transaction.type, transaction.value);
            }
            return Content(data);
        }

        private string performAccountUpdate(int srcAccNo, int destAccNo, TransactionTypes type, int amount)
        {
            string response = null;
            switch (type)
            {
                case TransactionTypes.withdrawl:
                    response = getStringCommand.get("account/transact/withdraw/" + srcAccNo + "/" + amount);
                    break;
                case TransactionTypes.deposit:
                    response = getStringCommand.get("account/transact/deposit/" + srcAccNo + "/" + amount);
                    break;
                case TransactionTypes.transfer:
                    response = getStringCommand.get("account/transact/transfer/" + srcAccNo + "/" + destAccNo + "/" + amount);
                    break;
            }
            return response;
        }
    }
}
