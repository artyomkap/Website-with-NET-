using InternetAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetAssignment.Services
{
    public class ShoppingCartService
    {
        private readonly AppDataContext _context;

        public ShoppingCartService(AppDataContext context)
        {
            _context = context;
        }

        public async Task AddItemToCartAsync(Product product, int quantity)
        {
            var cartItem = await _context.ShoppingCartItems
                .SingleOrDefaultAsync(s => s.Product.ProductId == product.ProductId);

            if (cartItem == null)
            {
                cartItem = new CartItems
                {
                    Product = product,
                    Quantity = quantity
                };

                _context.ShoppingCartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            await _context.SaveChangesAsync();
        }
    }
}
