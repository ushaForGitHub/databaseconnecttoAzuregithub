﻿using databaseconnecttoAzure.Models;
using databaseconnecttoAzure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace databaseconnecttoAzure.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> products;

        public void OnGet()
        {
            ProductService productService = new ProductService();
            products = productService.GetProducts();
        }
    }
}