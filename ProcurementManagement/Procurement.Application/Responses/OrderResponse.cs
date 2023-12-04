
namespace Procurement.Application.Responses
{
    public class OrderResponse
    {
        public int Id { get; protected set; }
        /********************************************************/
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Quantity { get; set; }
    }
}
