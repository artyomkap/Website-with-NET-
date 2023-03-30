using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using InternetAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetAssignment.Pages
{
    public class ShoppingCartModel : PageModel
    {
        private readonly AppDataContext _context;       

        public List<CartItem> CartItems { get; set; }

        public ShoppingCartModel(AppDataContext context)
        {
            _context = context;
            CartItems = new List<CartItem>();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var cartItems = await _context.CartItems.Where(c => c.UserId == User.Identity.Name).ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAddAsync(int productId, int quantity)
        {
            var cartItem = new CartItem()
            {
                ProductId = productId,
                Quantity = quantity,
                UserId = User.Identity.Name
            };
            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostUpdateAsync(int itemId, int quantity)
        {
            var cartItem = await _context.CartItems.FindAsync(itemId);
            if (cartItem == null || cartItem.UserId != User.Identity.Name)
            {
                return NotFound();
            }
            cartItem.Quantity = quantity;
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int itemId)
        {
            var cartItem = await _context.CartItems.FindAsync(itemId);
            if (cartItem == null || cartItem.UserId != User.Identity.Name)
            {
                return NotFound();
            }
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }


    }
}
