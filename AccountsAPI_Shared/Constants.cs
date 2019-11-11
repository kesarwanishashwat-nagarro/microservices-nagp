using System;
using System.Collections.Generic;
using AccountsAPI_Shared.Models;

namespace AccountsAPI_Shared
{
    public static class Constants
    {
        public enum AccountTypes
        {
            Saving, Current
        }

        public static List<Branch> branches = new List<Branch>() {
            new Branch() { Id = 101, Name = "Sector 18" },
            new Branch() { Id = 102, Name = "Sector 21" },
            new Branch() { Id = 103, Name = "Palam Vihar" }
        };

        public static List<Account> accounts = new List<Account>()
        {
            new Account(){ Number=12345, type=AccountTypes.Current, isClosed = false, balance = 763484, userId= 1, branchId = 101 },
            new Account(){ Number=12346, type=AccountTypes.Saving , isClosed = false, balance = 14234234, userId= 2, branchId = 102},
            new Account(){ Number=12347, type=AccountTypes.Saving , isClosed = true, balance = 234234, userId= 3, branchId = 101},
            new Account(){ Number=12348, type=AccountTypes.Current, isClosed = false, balance = 0 , userId= 2, branchId = 103},
            new Account(){ Number=12349, type=AccountTypes.Current, isClosed = false, balance = 3456, userId= 1, branchId = 101 }
        };
    }
}
