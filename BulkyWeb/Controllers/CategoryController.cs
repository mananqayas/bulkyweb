using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers;

public class CategoryController(ApplicationDbContext db) : Controller
{



    // GET
    public IActionResult Index()
    {

        List<Category> objCategoryList = db.Categories.ToList();
        return View(objCategoryList);
    }

    public IActionResult Create()
    {

        return View();
    }
    [HttpPost]
    public IActionResult Create(Category obj)
    {

        if (obj.Name == obj.DisplayOrder.ToString())
        {
            
            ModelState.AddModelError("name", "Display order cannot match the name");
        }

        if (ModelState.IsValid)
        {
            
            db.Categories.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View();



    }
}