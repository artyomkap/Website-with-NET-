using InternetAssignment.Models;
using InternetAssignment.Pages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InternetAssignment.Services;

namespace InternetAssignment.Pages
{
    public class FlexProductModel : PageModel
    {

        private readonly AppDataContext _db;
        private readonly ShoppingCartService _shoppingCartService;
        public FlexProductModel(AppDataContext db, ShoppingCartService shoppingCartService)
        {
            _db = db;
            _shoppingCartService = shoppingCartService;
        }
        public Product Products { get; set; }

        public async Task<IActionResult> OnPostAsync(int productId, int quantity)
        {

            var product = await _db.Products.FindAsync(productId);

            if (product == null)
            {
                return NotFound();
            }

            var shoppingCartService = new ShoppingCartService(_db);
            await _shoppingCartService.AddItemToCartAsync(product, quantity);

            return RedirectToPage("ShoppingCart");
            
        }
        public IActionResult OnGet(int id)
        {
            Products = _db.Products.Find(id);

            if (Products == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
