using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using InternetAssignment.Models;
using InternetAssignment.Pages;
using System.Threading.Tasks;

namespace InternetAssignment.Pages
{
    public class ProductsModel : PageModel
    {        
        public List<Product> Products { get; set; }

        public readonly AppDataContext _db;

        public ProductsModel(AppDataContext db)
        {
            _db = db;
            
        }

        public void OnGet()
        {
            Products = _db.Products.ToList();
        }
        

    }

}
