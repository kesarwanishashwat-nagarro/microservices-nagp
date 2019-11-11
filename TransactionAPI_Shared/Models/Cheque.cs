using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionAPI_Shared.Models
{
    public class Cheque
    {
        public int id { get; set; }

        public int pages = 200; 

        public bool isBlocked = false;
        public int accountNumber { get; set; }
    }
}
