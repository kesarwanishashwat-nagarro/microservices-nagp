using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionAPI_Shared.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime performedAt { get; set; }
        public Constants.TransactionTypes type { get; set; }
        public int srcAccountNumber { get; set; }
        public int ? destAccountNumber { get; set; }
        public int value { get; set; }
    }
}
