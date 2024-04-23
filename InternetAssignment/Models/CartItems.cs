namespace InternetAssignment.Models
{
    public class CartItems
    {
        public int Id { get; set; }
        public int ShoppingCartItemId { get; set; }
        public Product Product { get; set; }        
        public int Quantity { get; set; }

    }
}
