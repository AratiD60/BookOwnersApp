using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookOwnersApp.Models;
using BookOwnersApp.Services;
using BookOwnersApp.ViewModel;

namespace BookOwnersApp.Controllers
{
    public class ChildOwnedBooksController : Controller
    {
        IBookOwnerService _bookOwnerService;
        public ChildOwnedBooksController(IBookOwnerService bookOwnerService)
        {
            _bookOwnerService = bookOwnerService;
        }

        public IActionResult Index()
        {
            var books = _bookOwnerService.GetBooksByChildOwners();

            if (books.Count() <= 0)
            {
                ViewBag.BookMessage = $"has no books";
            }

            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View(books);
        }

      
    }
}
