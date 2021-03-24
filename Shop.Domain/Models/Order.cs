namespace Shop.Domain.Models
{
    using System.Collections.Generic;

    public class Order
    {
        public int Id { get; set; }
        public string OrderRef { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
