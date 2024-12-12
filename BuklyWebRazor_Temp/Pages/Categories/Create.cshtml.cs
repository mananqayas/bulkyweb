using BuklyWebRazor_Temp.Data;
using BuklyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BuklyWebRazor_Temp.Pages.Categories;
[BindProperties]
public class Create(ApplicationDbContext db) : PageModel
{

    public Category Category { get; set; }
    public void OnGet()
    {
        
    }

    public IActionResult OnPost()
    {
        
        db.Categories.Add(Category);
        db.SaveChanges();
        TempData["success"] = "Category created successfully";
        return RedirectToPage("./Index");
    }
}