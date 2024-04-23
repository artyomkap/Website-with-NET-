using InternetAssignment.Models;
using InternetAssignment.Pages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;



namespace InternetAssignment.Pages
{


    [Authorize(Roles = "Admin")]
    public class AdminProductsModel : PageModel
    {
        public readonly AppDataContext _db;

        [BindProperty]        
        public Product Products { get; set; }
        public AdminProductsModel(AppDataContext db)
        {
            _db = db;
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _db.Products.Add(Products);
                _db.SaveChanges();

                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                // Log the exception
                // You can use a logging framework like Serilog or log to a file or database
                // This example logs the exception to the console
                Console.Error.WriteLine(ex.ToString());

                ModelState.AddModelError("", "An error occurred while adding the product.");

                return Page();
            }
        }
    }
}
