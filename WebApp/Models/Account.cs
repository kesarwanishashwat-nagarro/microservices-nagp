namespace WebApp.Models
{

    public enum AccountTypes
    {
        Saving, Current
    }
    public class Account
    {
        public int Number { get; set; }
        public AccountTypes type { get; set; }
        public bool isClosed { get; set; }
        public int userId { get; set; }

        public int balance { get; set; }
        public int branchId { get; set; }
    }
}