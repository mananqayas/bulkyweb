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

        if (obj.Name.ToLower() == "test")
        {
            
            ModelState.AddModelError("", "Test is in invalid value");
        }

        if (!ModelState.IsValid) return View();
        db.Categories.Add(obj);
        db.SaveChanges();
        TempData["Success"] = "Category created successfully";
        return RedirectToAction("Index");



    }
    
    
    
    public IActionResult Edit(int? id)
    {

        if (id is null or 0)
        {

            return NotFound();
        }
        
        var categoryFromDb = db.Categories.Find(id);
      

        if (categoryFromDb == null)
        {
            return NotFound();
        }

        return View(categoryFromDb);
    }
    [HttpPost]
    public IActionResult Edit(Category obj)
    {
        if (!ModelState.IsValid) return View();
        db.Categories.Update(obj);
        db.SaveChanges();
        TempData["Success"] = "Category updated successfully";
        return RedirectToAction("Index");



    }
    
    public IActionResult Delete(int? id)
    {

        if (id is null or 0)
        {

            return NotFound();
        }
        
        var categoryFromDb = db.Categories.Find(id);
      

        if (categoryFromDb == null)
        {
            return NotFound();
        }

        return View(categoryFromDb);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(int? id)
    {
        var obj = db.Categories.Find(id);
        
        if(obj == null) {return NotFound();}
        db.Categories.Remove(obj);
        db.SaveChanges();
        TempData["Success"] = "Category deleted successfully";
        return RedirectToAction("Index");



    }
}