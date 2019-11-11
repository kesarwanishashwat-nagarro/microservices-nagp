using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class OrderController : Controller
    {
        private PostCommand<Order> postCommand;
        private GetAllCommand<Order> getAllCommand;
        private DeleteCommand deleteCommand;
        public OrderController(PostCommand<Order> command, GetAllCommand<Order> getAllCommand,
             DeleteCommand deleteCommand)
        {
            this.postCommand = command;
            this.getAllCommand = getAllCommand;
            this.deleteCommand = deleteCommand;
        }

        [HttpGet("orders")]
        public IEnumerable<Order> Get()
        {
            IEnumerable<Order> data = getAllCommand.getAll("transaction/order");
            return data;
        }


        [HttpGet("orders/account/{accountNo}")]
        public IEnumerable<Order> GetOrdersByAccount(int accountNo)
        {
            IEnumerable<Order> data = getAllCommand.getAll("transaction/order/" + accountNo);
            return data;
        }

        [HttpDelete("cheque/block/{id}")]
        public string BlockCheque(int id)
        {
           return deleteCommand.delete("transaction/order/cheque/block/" + id);
        }

        [HttpPost("cheque/issue")]
        public IActionResult PostData(ChequeIssuePayload payload)
        {
            var order = new Order()
            {
                accountNumber = payload.accountNumber,
                performedAt = DateTime.Now,
                type = OrderType.cheque,
                userid = payload.userId,
                Id = 0
            };
            string data = postCommand.post(order, "transaction/order");
            return Content(data);
        }

    }
}
