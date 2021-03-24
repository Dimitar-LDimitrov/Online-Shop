﻿namespace Shop.Domain.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
