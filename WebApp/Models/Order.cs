using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Models
{
    public enum OrderType
    {
        cheque,
        debitcard,
        creditcard
    }
    public class Order
    {
        public int Id { get; set; }
        public DateTime performedAt { get; set; }
        public OrderType type { get; set; }
        public int accountNumber { get; set; }
        public int userid { get; set; }
    }
}
