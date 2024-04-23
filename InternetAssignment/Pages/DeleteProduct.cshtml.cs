using InternetAssignment.Models;
using InternetAssignment.Pages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace InternetAssignment.Pages
{

    [Authorize(Roles = "Admin")]
    public class DeleteProductModel : PageModel
    {
        private readonly AppDataContext _db;

        public DeleteProductModel(AppDataContext db)
        {
            _db = db;
        }

        public Product Products { get; set; }

        public IActionResult OnGet(int id)
        {
            Products = _db.Products.Find(id);

            if (Products == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            Products = _db.Products.Find(id);

            if (Products == null)
            {
                return NotFound();
            }

            _db.Products.Remove(Products);
            _db.SaveChanges();

            return RedirectToPage("./Products");
        }

    }
}
