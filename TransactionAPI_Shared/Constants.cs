using System;
using System.Collections.Generic;
using TransactionAPI_Shared.Models;

namespace TransactionAPI_Shared
{
    public static class Constants
    {
        public enum TransactionTypes
        {
            payment,
            transfer,
            withdrawl,
            deposit
        }
        public enum OrderType
        {
            cheque,
            debitcard,
            creditcard
        }
        public static List<Cheque> chequesIssued = new List<Cheque>()
        {
            new Cheque(){ accountNumber  = 12345},
            new Cheque(){ accountNumber  = 12349}
        };
        public static List<Order> orders = new List<Order>()
        {
            new Order(){ Id = 1, accountNumber = 12345, type = OrderType.cheque, performedAt = new DateTime(2019,2,17), userid =1 },
            new Order(){ Id = 2, accountNumber = 12349, type = OrderType.cheque, performedAt = new DateTime(2019,4,01), userid =3 }
        };

        public static List<Transaction> transactions = new List<Transaction>()
        {
            new Transaction() { srcAccountNumber = 12345, Id = 1, performedAt = new DateTime(2019,2,17), type=TransactionTypes.withdrawl, value=120 },
            new Transaction() { srcAccountNumber = 12349, Id = 2, performedAt = new DateTime(2019,11,07), type=TransactionTypes.deposit, value=7342 },
            new Transaction() { srcAccountNumber = 12347, destAccountNumber=12345, Id = 3, performedAt = new DateTime(2019,6,21), type=TransactionTypes.transfer, value=424 },
            new Transaction() { srcAccountNumber = 12348, Id = 4, performedAt = new DateTime(2019,3,01), type=TransactionTypes.withdrawl, value=535 },
            new Transaction() { srcAccountNumber = 12349, Id = 5, performedAt = new DateTime(2019,8,30), type=TransactionTypes.payment, value=7775 }
        };
    }
}
