using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionAPI_Shared.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime performedAt { get; set; }
        public Constants.OrderType type { get; set; }
        public int accountNumber { get; set; }
        public int userid { get; set; }
    }
}
