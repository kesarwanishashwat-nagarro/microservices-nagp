using AccountsAPI_Shared;
using AccountsAPI_Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountAPI.Controllers
{
    [Route("api/transact")]
    [ApiController]
    public class TransactController : ControllerBase
    {
        [HttpGet("withdraw/{accNo}/{amount}")]
        public string WithdrawMoney(int accNo, int amount)
        {
            Account account = Constants.accounts.Find(ac => ac.Number == accNo);
            if(account != null)
            {
                account.balance -= amount;
                return "You have Withdrawn Rs"+amount+ " from account number "+accNo;
            }
            return "Account not found";
        }

        [HttpGet("deposit/{accNo}/{amount}")]
        public string DepositMoney(int accNo, int amount)
        {
            Account account = Constants.accounts.Find(ac => ac.Number == accNo);
            if (account != null)
            {
                account.balance += amount;
                return "You have Deposited Rs" + amount + " in account number " + accNo;
            }
            return "Account not found";
        }

        [HttpGet("transfer/{srcAcc}/{destAcc}/{amount}")]
        public string TransferMoney(int srcAcc, int destAcc, int amount)
        {
            Account srcAccount = Constants.accounts.Find(ac => ac.Number == srcAcc);
            Account destAccount = Constants.accounts.Find(ac => ac.Number == destAcc);
            if (srcAccount != null && destAccount != null)
            {
                srcAccount.balance -= amount;
                destAccount.balance += amount;
                return "You have transferred Rs" + amount + " from account number " + srcAcc + " to " + destAcc;
            }
            return "Source/Destination Account not found";
        }

    }
}
