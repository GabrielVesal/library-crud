using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using LogicLibrary.Services;

namespace Library.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly BookManager _bookManager;

    public HomeController(ILogger<HomeController> logger, BookManager bookManager)
    {
        _logger = logger;
        _bookManager = bookManager;
    }

    public IActionResult Index()
    {
        var books = _bookManager.ListBooks();
        return View(books);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(LogicLibrary.Models.Book book)
    {
        _bookManager.AddBook(book);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(string id)
    {
        var book = _bookManager.GetBook(id);
        return View(book);
    }
    
    public IActionResult View(string id)
    {
        var book = _bookManager.GetBook(id);
        return View(book);
    }

    [HttpPost]
    public IActionResult Edit(string id, LogicLibrary.Models.Book book) 
    {
        _bookManager.UpdateBook(id,book);
        return RedirectToAction("Index");
    }
    
    public IActionResult Remove(string id)
    {
        var book =_bookManager.GetBook(id);
        return View(book);
    }

    [HttpPost]
    public IActionResult RemoveBook(string id)
    {
        _bookManager.RemoveBook(id);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
