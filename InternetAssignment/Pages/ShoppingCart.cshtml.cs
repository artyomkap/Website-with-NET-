using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using InternetAssignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using InternetAssignment.Services;


namespace InternetAssignment.Pages
{
    public class ShoppingCartModel : PageModel
    {
        
        private readonly AppDataContext _context;

        public ShoppingCartModel(AppDataContext context)
        {
            _context = context;
        }

        public List<CartItems> ShoppingCartItems { get; set; }

        public int CartTotal => ShoppingCartItems.Sum(item => item.Product.ProductPrice * item.Quantity);

        public async Task<IActionResult> OnGetAsync()
        {
            ShoppingCartItems = await _context.ShoppingCartItems
                .Include(s => s.Product)
                .ToListAsync();           

            return Page();
        }

        public async Task<IActionResult> OnPostUpdateCart(int cartItemId1, int quantity)
        {
            var cartItem = await _context.ShoppingCartItems.FindAsync(cartItemId1);

            if (cartItem == null)
            {
                return NotFound();
            }

            cartItem.Quantity = quantity;
            _context.ShoppingCartItems.Update(cartItem);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemoveFromCartAsync(int cartItemId1)
        {
            var cartItem = await _context.ShoppingCartItems.FindAsync(cartItemId1);

            if (cartItem == null)
            {
                return NotFound();
            }

            _context.ShoppingCartItems.Remove(cartItem);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }


    }
}
