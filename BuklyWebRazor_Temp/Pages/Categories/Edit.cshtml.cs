using BuklyWebRazor_Temp.Data;
using BuklyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BuklyWebRazor_Temp.Pages.Categories;
[BindProperties]
public class Edit(ApplicationDbContext db) : PageModel
{
    public required Category Category { get; set; }
    public void OnGet( int? id)
    {

        if (id != null && id != 0)
        {

            Category = db.Categories.Find(id);
        }
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            
            db.Categories.Update(Category);

            db.SaveChanges();
            TempData["success"] = "Category updated";
            
            return RedirectToPage("./index");
        }

        return Page();





    }
}