using System.Collections.Generic;

namespace Model.DTOs
{
    public class OrderCreateDto
    {
        public int ClientId { get; set; }
        public List<OrderDetailCreateDto> Items { get; set; }
    }

    public class OrderDetailCreateDto 
    {
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderDto
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public ClientDto Client { get; set; }
        public decimal Iva { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }

        public List<OrderDetailDto> Items { get; set; }
    }

    public class OrderDetailDto
    {
        public int OrderDetailId { get; set; }

        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public decimal Iva { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
    }
}
