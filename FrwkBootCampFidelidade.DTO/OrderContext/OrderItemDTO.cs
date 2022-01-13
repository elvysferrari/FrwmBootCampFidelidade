namespace FrwkBootCampFidelidade.DTO.OrderContext
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderDTO OrderDTO { get; set; }
        public string Observation { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }

    }
}
