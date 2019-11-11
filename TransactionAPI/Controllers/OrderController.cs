using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TransactionAPI_Shared;
using TransactionAPI_Shared.Models;

namespace TransactionAPI.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Order> GetAllOrders()
        {
            return Constants.orders;
        }

        [HttpGet("{accNo}")]
        public IEnumerable<Order> GetAllOrdersByAccount(int accNo)
        {
            return Constants.orders.Where(t => t.accountNumber == accNo);
        }

        [HttpDelete("cheque/block/{id}")]
        public string BlockCheque(int chequeId)
        {
            var cheque = Constants.chequesIssued.Find(t => t.id == chequeId);
            if (cheque != null)
            {
                cheque.isBlocked = true;
                return "Cheque Blocked Successfully";
            }
            return "No Cheque Found";
        }

        [HttpPost]
        public string Post([FromBody] Order order)
        {
            order.Id = Constants.orders.Max(o => o.Id) + 1;
            Constants.orders.Add(order);
            if (order.type == Constants.OrderType.cheque)
            {
                var cheque = new Cheque() { accountNumber = order.accountNumber };
                cheque.id = Constants.chequesIssued.Max(c => c.id) + 1;
                Constants.chequesIssued.Add(cheque);
            }
            return "Order successful";
        }

    }
}
