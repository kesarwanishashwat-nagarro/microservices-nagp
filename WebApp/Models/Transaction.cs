using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Models
{
    public enum TransactionTypes
    {
        payment,
        transfer,
        withdrawl,
        deposit
    }
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime performedAt { get; set; }
        public TransactionTypes type { get; set; }
        public int srcAccountNumber { get; set; }
        public int ? destAccountNumber { get; set; }
        public int value { get; set; }
    }
}
