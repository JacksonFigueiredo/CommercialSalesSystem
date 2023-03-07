﻿using Microsoft.AspNetCore.Mvc;
using SalesWebCommercial.Services;

namespace SalesWebCommercial.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }


        public IActionResult Index()
        {
            var list = _sellerService.FindAll();

            return View(list);
        }

        public IActionResult Create() 
        {
            return View();
        }
    }
}
