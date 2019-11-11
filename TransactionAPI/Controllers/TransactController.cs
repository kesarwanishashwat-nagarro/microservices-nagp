using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TransactionAPI_Shared;
using TransactionAPI_Shared.Models;

namespace TransactionAPI.Controllers
{
    [Route("api/crud")]
    [ApiController]
    public class TransactionAPI : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Transaction> GetAllTransactions()
        {
            return Constants.transactions;
        }

        [HttpGet("{accNo}")]
        public IEnumerable<Transaction> GetAllTransactionsByAccount(int accNo)
        {
            return Constants.transactions.Where(t => t.srcAccountNumber == accNo);
        }

        [HttpPost]
        public string Post([FromBody] Transaction trans)
        {
            Constants.transactions.Add(trans);
            return "successful";
        }

    }
}
