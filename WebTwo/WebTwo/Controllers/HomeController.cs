﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebTwo.Models;
namespace WebTwo.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {

            List<string> results = new List<string>();
            foreach(Product p in Product.GetProducts())
            {
                string name = p?.Name ?? "<No Name>";
                decimal? price = p?.Price ?? 0;
                string relatedName = p?.Related?.Name ?? "<None>";
                results.Add($"Name: {name}, Price: {price}, Related: {relatedName}");
            }
                        return View(results);
        }
    
    }
}