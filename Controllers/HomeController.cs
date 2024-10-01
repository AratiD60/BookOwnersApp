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
    public class HomeController : Controller
    {
        IBookOwnerService _bookOwnerService;
        public HomeController(IBookOwnerService bookOwnerService)
        {
            _bookOwnerService = bookOwnerService;
        }

        public IActionResult Index()
        {
            var bookOwners = _bookOwnerService.GetAllBookOwners();

            if (bookOwners.Count() <= 0)
            {
                ViewBag.BookMessage = $"has no books";
            }

            //var ownerBooksViewModel = new OwnerBooksViewModel()
            //{
            //    BookOwners = bookOwners
            //};

            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View(bookOwners);
        }

         [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
