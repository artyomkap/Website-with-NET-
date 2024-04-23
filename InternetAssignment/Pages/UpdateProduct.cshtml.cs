using InternetAssignment.Models;
using InternetAssignment.Pages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace InternetAssignment.Pages
{
    [Authorize(Roles = "Admin")]
    public class UpdateProductModel : PageModel
    {

        public readonly AppDataContext _db;

        [BindProperty]
        public Product Products { get; set; }
        public UpdateProductModel (AppDataContext db)
        {
            _db = db;
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

        public IActionResult OnPost()
        {

            if (Products == null)
            {
                return NotFound();
            }

            _db.Products.Update(Products);
            _db.SaveChanges();

            return RedirectToPage("./Products");

        }
    }
}
