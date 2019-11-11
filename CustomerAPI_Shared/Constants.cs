using CustomerAPI.Models;
using System;
using System.Collections.Generic;

namespace CustomerAPI_Shared
{
    public static class Constants
    {
        public enum AccountTypes
        {
            Saving, Current
        }

        public static List<Customer> customers = new List<Customer>()
        {
            new Customer(){Id = 1, Name="Shashwat" },
            new Customer(){ Id = 2,Name="Vikrant" },
            new Customer(){ Id = 3,Name="Mayank" },
            new Customer(){ Id = 4,Name="Raj" }
        };
    }
}
