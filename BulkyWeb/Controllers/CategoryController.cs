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
}