using System.Collections.Generic;

namespace Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public decimal Iva { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }

        public List<OrderDetail> Items { get; set; }
    }
}
