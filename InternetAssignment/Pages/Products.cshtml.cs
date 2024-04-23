using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using InternetAssignment.Models;
using InternetAssignment.Pages;
using System.Threading.Tasks;
using InternetAssignment.Services;

namespace InternetAssignment.Pages
{
    public class ProductsModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        

        public List<Product> Products { get; set; }

        public readonly AppDataContext _db;
        private readonly ShoppingCartService _shoppingCartService;

        public ProductsModel(AppDataContext db, ShoppingCartService shoppingCartService)
        {
            _db = db;
            _shoppingCartService = shoppingCartService;
        }

        public async Task OnGetAsync(string SearchTerm)
        {
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Products = await _db.Products
                    .Where(p => p.ProductName.Contains(SearchTerm) || p.ProductDescription.Contains(SearchTerm))
                    .ToListAsync();
            }
            else
            {
                Products = await _db.Products.ToListAsync();
            }
        }


        /*public void OnGet()
        {
            Products = _db.Products.ToList();
        }
*/
        public async Task AddItemToCartAsync(Product product, int quantity)
        {
            var cartItem = await _db.ShoppingCartItems
                .SingleOrDefaultAsync(s => s.Product.ProductId == product.ProductId);

            if (cartItem == null)
            {
                cartItem = new CartItems
                {
                    Product = product,
                    Quantity = quantity
                };

                _db.ShoppingCartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            await _db.SaveChangesAsync();
        }


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


            var searchTerm = Request.Query["searchTerm"].ToString();
            await OnGetAsync(searchTerm);
            return Page();
        }

    }

}
