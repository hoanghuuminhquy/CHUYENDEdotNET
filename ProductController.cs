using System;
using System.Web;
using System.Linq;
using Shop_Asp.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using Shop_Asp.Views.ViewModel;

namespace Shop_Asp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShopContext _dbContext;
        private readonly IHostingEnvironment hostingEnvironment;

        public ProductController(ShopContext dbContext, IHostingEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            this.hostingEnvironment = hostingEnvironment;
                //không biết cách e lấy vậy có đúng không
        }

        public IActionResult Index()
        {
            return View(_dbContext.product.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductCreateViewModel a)
        {
            string uniqueFileName = null;
            string filePath = null;
            if (a.image1!=null)
            {
                string uploadsFoder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName =a.image1.FileName; /*Guid.NewGuid().ToString() + "_" + */
                filePath = Path.Combine(uploadsFoder, uniqueFileName);
                a.image1.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            Product newProduct = new Product
            {
                name = a.name,
                detail = a.detail,
                price = a.price,
                pricenew = a.pricenew,
                image = "/images/" + uniqueFileName,
                date = a.date,
                order = a.order,
                status = a.status,
                groupproduct_id = a.groupproduct_id
            };
            _dbContext.Add(newProduct);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                Product a = _dbContext.product.Where(s => s.id == id).First();
                _dbContext.product.Remove(a);
                _dbContext.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }

        }
        public ActionResult Update(int id)
        {
            return View(_dbContext.product.Where(s => s.id == id).First());
        }
        [HttpPost]
        public ActionResult UpdateProduct(Product a)
        {
            Product d = _dbContext.product.Where(s => s.id == a.id).First();
            d.name = a.name;
            d.detail = a.detail;
            d.price = a.price;
            d.pricenew = a.pricenew;
            d.image = a.image;
            d.date = a.date;
            d.order = a.order;
            d.status = a.status;
            d.groupproduct_id = a.groupproduct_id;
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
    }
}
