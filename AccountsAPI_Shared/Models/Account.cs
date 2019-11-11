using AccountsAPI_Shared;

namespace AccountsAPI_Shared.Models
{
    public class Account
    {
        public int Number { get; set; }
        public Constants.AccountTypes type { get; set; }
        public bool isClosed { get; set; }
        public int balance { get; set; }
        public int userId { get; set; }
        public int branchId { get; set; }
    }
}