﻿using AdventureWorks.EfModels;
using AdventureWorks.Interface;
using AdventureWorks.Models;
using AdventureWorks.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Printing;

namespace AdventureWorks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AdventureWorksContext _db;
        private readonly IRepository<ProductVM> _productRepo;
        private readonly IRepository<ProductCategoryVM> _productCategoryRepo;

        public HomeController(ILogger<HomeController> logger
                             ,AdventureWorksContext db
                             , IRepository<ProductVM> productRepo
                             , IRepository<ProductCategoryVM> productCategoryRepo)
        {
            _logger = logger;
            _db = db;
            _productRepo = productRepo;
            _productCategoryRepo = productCategoryRepo;
        }

        public IActionResult Index(string sortOrder,string searchString,int? pageNumber, int pageSize = 4)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["IDSortParm"] = string.IsNullOrEmpty(sortOrder) ? "idSortDesc" : "";
            ViewData["NameSortParm"] = sortOrder == "Name" ? "nameSortDesc" : "Name";
            ViewData["NumSortParm"] = sortOrder == "Num" ? "numSortDesc" : "Num";

            List<ProductVM> products = _productRepo.GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                products =
                    products.Where(p => p.Name.Contains(searchString) ||
                                        p.ProductNumber.Contains(searchString)).ToList();
            }


            switch (sortOrder)
            {
                case "numSortDesc":
                    products =
                        products.OrderByDescending(p => p.ProductNumber).ToList();
                    break;
                case "Num":
                    products =
                        products.OrderBy(p => p.ProductNumber).ToList();
                    break;
                case "nameSortDesc":
                    products =
                        products.OrderByDescending(p => p.Name).ToList();
                    break;
                case "Name":
                    products =
                        products.OrderBy(p => p.Name).ToList();
                    break;
                case "idSortDesc":
                    products =
                        products.OrderByDescending(p => p.ProductId).ToList();
                    break;
                default:
                    products =
                        products.OrderBy(p => p.ProductId).ToList();
                    break;
            }

            int pageIndex = pageNumber ?? 1;
            var count = products.Count();
            var items = products.Skip((pageIndex - 1) * pageSize)
                                            .Take(pageSize).ToList();
            var paginatedProducts = new PaginatedList<ProductVM>(items
                                                                , count
                                                                , pageIndex
                                                                , pageSize);



            return View(paginatedProducts);

        }
        public IActionResult IndexProductCategory(string sortOrder, string searchString, int? pageNumber, int pageSize = 7)
        {
           
            ViewData["CurrentSort"] = sortOrder;
            ViewData["IDSortParm"] = string.IsNullOrEmpty(sortOrder) ? "idSortDesc" : "";
            ViewData[" CateNameSortParm"] = sortOrder == "CategoryName" ? "CateNameSortDesc" : "CategoryName";
            ViewData["NumSortParm"] = sortOrder == "Num" ? "numSortDesc" : "Num";

            List<ProductCategoryVM> productCategories = _productCategoryRepo.GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                productCategories =
                    productCategories.Where(pc => pc.ProductName.Contains(searchString) ||
                                                 pc.ProductNumber.Contains(searchString)||
                                                 pc.CategoryName.Contains(searchString)).ToList();
            }


            switch (sortOrder)
            {
                case "numSortDesc":
                    productCategories =
                        productCategories.OrderByDescending(p => p.ProductNumber).ToList();
                    break;
                case "Num":
                    productCategories =
                        productCategories.OrderBy(p => p.ProductNumber).ToList();
                    break;
                case "nameSortDesc":
                    productCategories =
                        productCategories.OrderByDescending(p => p.CategoryName).ToList();
                    break;
                case "Name":
                    productCategories =
                        productCategories.OrderBy(p => p.CategoryName).ToList();
                    break;
                case "idSortDesc":
                    productCategories =
                        productCategories.OrderByDescending(p => p.ProductID).ToList();
                    break;
                default:
                    productCategories =
                        productCategories.OrderBy(p => p.ProductID).ToList();
                    break;
            }

            int pageIndex = pageNumber ?? 1;
            var count = productCategories.Count();
            var items = productCategories.Skip((pageIndex - 1) * pageSize)
                                            .Take(pageSize).ToList();
            var paginatedProductCategories = new PaginatedList<ProductCategoryVM>(items
                                                                , count
                                                                , pageIndex
                                                                , pageSize);

            return View(paginatedProductCategories);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
} 