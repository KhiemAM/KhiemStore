using KhiemStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KhiemStore.Controllers
{
    public class CollectionController : Controller
    {
        // GET: Collection
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllProduct()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<Product> products  = db.Products.ToList(); 
            ViewBag.Content = "Tất cả sản phẩm";
            ViewBag.title = "Tất cả sản phẩm";

            //Sort
            //ViewBag.SortButton = SortButton;
            //ViewBag.SortStyle = SortStyle;
            //if (SortButton == "MoiNhat")
            //{
            //    products = products.OrderByDescending(row => row.CreatedDate).ToList();
            //}
            //else if (SortButton == "Gia")
            //{
            //    if (SortStyle == "TangDan")
            //    {
            //        products = products.OrderBy(row => row.Price).ToList();
            //    }
            //    else
            //    {
            //        products = products.OrderByDescending(row => row.Price).ToList();
            //    }
            //}
            return View(products);
        }

        public ActionResult Laptop(int categoryid)
        {

            CompanyDBContext db = new CompanyDBContext();
            List<Product> products = db.Products.Where(row => row.CategoryID == categoryid).ToList();
            Category category = db.Categories.Where(row => row.CategoryID == categoryid).FirstOrDefault();
            ViewBag.Content = "Tất cả sản phẩm / " + category.CategoryName;
            ViewBag.title = category.CategoryName;
            ViewBag.categoryid = categoryid;
            //Sort
            //ViewBag.SortButton = SortButton;
            //ViewBag.SortStyle = SortStyle;
            //if (SortButton == "MoiNhat")
            //{
            //    products = products.OrderByDescending(row => row.CreatedDate).ToList();
            //}
            //else if (SortButton == "Gia")
            //{
            //    if (SortStyle == "TangDan")
            //    {
            //        products = products.OrderBy(row => row.Price).ToList();
            //    }
            //    else
            //    {
            //        products = products.OrderByDescending(row => row.Price).ToList();
            //    }
            //}
            return View(products);
        }
        public ActionResult BrandLaptop(int brandid, int categoryid, string SortButton = "PhoBien", string SortStyle = "")
        {
            CompanyDBContext db = new CompanyDBContext();
            List<Product> products = db.Products.Where(row => row.BrandID == brandid && row.CategoryID == categoryid).ToList();
            Brand brand = db.Brands.Where(row => row.CategoryID == categoryid && row.BrandID == brandid).FirstOrDefault();
            ViewBag.Content = "Tất cả sản phẩm / " + brand.Category.CategoryName + " " + brand.BrandName;
            ViewBag.title = brand.Category.CategoryName + " " + brand.BrandName;

            //Sort
            ViewBag.SortButton = SortButton;
            ViewBag.SortStyle = SortStyle;
            if (SortButton == "MoiNhat")
            {
                products = products.OrderByDescending(row => row.CreatedDate).ToList();
            }
            else if (SortButton == "Gia")
            {
                if (SortStyle == "TangDan")
                {
                    products = products.OrderBy(row => row.Price).ToList();
                }
                else
                {
                    products = products.OrderByDescending(row => row.Price).ToList();
                }
            }
            return View(products);
        }
    }
}