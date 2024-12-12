using BuklyWebRazor_Temp.Data;
using BuklyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BuklyWebRazor_Temp.Pages.Categories;
[BindProperties]
public class Delete(ApplicationDbContext db) : PageModel
{
    public required Category Category { get; set; }
    public void OnGet(int? id)
    {
        if (id != null && id != 0)
        {

            Category = db.Categories.Find(id);
        }

    }

    public IActionResult OnPost()
    {

    Category? category = db.Categories.Find(Category.Id);
    if (category == null)
    {

        return NotFound();
    }
    
    db.Categories.Remove(category);
    db.SaveChanges();
    TempData["success"] = "Category deleted";
    return RedirectToPage("./Index");


    }
 


}