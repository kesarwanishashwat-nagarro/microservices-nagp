using AccountsAPI_Shared;
using AccountsAPI_Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountAPI.Controllers
{
    [Route("api/linked")]
    [ApiController]
    public class LinkedController : ControllerBase
    {
        [HttpGet("{userId}")]
        public IEnumerable<Account> GetAccountsbyUser(int userId)
        {
            return Constants.accounts.Where(acc => acc.userId == userId);
        }

        [HttpGet("{accountNo}/{branchId}")]
        public string ChangeAccountBranch(int accountNo, int branchId)
        {
            var branch = getBranch(branchId);
            if (branch != null)
            {
                Account acc = Constants.accounts.Find(ac => ac.Number == accountNo);
                if(acc!= null)
                {
                    if(!acc.isClosed)
                        acc.branchId = branchId;
                    else
                    {
                        return "Account is closed";
                    }
                }
                return "Account Transferred to branch - " + branch.Name;
            }
            return "Invalid branch";
        }

        private Branch getBranch(int branchId)
        { 
           return Constants.branches.Find(b => b.Id == branchId);
        }
    }
}
