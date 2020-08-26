using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.DataTransfer
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string  Address { get; set; }
        public int Quantity { get; set; }
    }
}
