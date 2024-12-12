using BuklyWebRazor_Temp.Data;
using BuklyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BuklyWebRazor_Temp.Pages.Categories;

public class Index(ApplicationDbContext db) : PageModel


{
    
    public List<Category> CategoryList { get; set; }
    public void OnGet()
    {
       CategoryList = db.Categories.ToList();
    }
}