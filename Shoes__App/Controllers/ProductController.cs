using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using DataLayer;

namespace Shoes__App.Controllers
{
    public class ProductController : Controller
    {
        BusinessLay Business = new BusinessLay();
        DataLay Data = new DataLay();

        // GET: Product
        public ActionResult Index()
        {
            return View(Business.GetProductEntities());
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.IdBrand = new SelectList(Data.GetCatBrands(), "IdBrand", "Code");
            ViewBag.IdCatalog = new SelectList(Data.GetCatCatalogs(), "IdCatalog", "Season");
            ViewBag.IdColor = new SelectList(Data.GetCatColors(), "IdColor", "Name");
            ViewBag.IdProvider = new SelectList(Data.GetCatProviders(), "IdProvider", "Name");
            ViewBag.IdType = new SelectList(Data.GetCatTypeProduct(), "IdType", "Code");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdType,IdColor,IdBrand,IdProvider,IdCatalog,Title,Nombre,Description,Observations,PriceDistributor,PriceClient,PriceMember,IsEnabled,Keywords,DateUpdate")] Products products)
        {
            if (ModelState.IsValid)
            {
                Business.AddProduct(products);
                return RedirectToAction("Index");
            }
            ViewBag.IdBrand = new SelectList(Data.GetCatBrands(), "IdBrand", "Code", products.IdBrand);
            ViewBag.IdCatalog = new SelectList(Data.GetCatCatalogs(), "IdCatalog", "Season", products.IdCatalog);
            ViewBag.IdColor = new SelectList(Data.GetCatColors(), "IdColor", "Name", products.IdColor);
            ViewBag.IdProvider = new SelectList(Data.GetCatProviders(), "IdProvider", "Name", products.IdProvider);
            ViewBag.IdType = new SelectList(Data.GetCatTypeProduct(), "IdType", "Code", products.IdType);
            return View(products);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = Business.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdBrand = new SelectList(Data.GetCatBrands(), "IdBrand", "Code", products.IdBrand);
            ViewBag.IdCatalog = new SelectList(Data.GetCatCatalogs(), "IdCatalog", "Season", products.IdCatalog);
            ViewBag.IdColor = new SelectList(Data.GetCatColors(), "IdColor", "Name", products.IdColor);
            ViewBag.IdProvider = new SelectList(Data.GetCatProviders(), "IdProvider", "Name", products.IdProvider);
            ViewBag.IdType = new SelectList(Data.GetCatTypeProduct(), "IdType", "Code", products.IdType);
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdType,IdColor,IdBrand,IdProvider,IdCatalog,Title,Nombre,Description,Observations,PriceDistributor,PriceClient,PriceMember,IsEnabled,Keywords,DateUpdate")] Products products)
        {
            if (ModelState.IsValid)
            {
                Business.Edit(products);
                return RedirectToAction("Index");
            }
            ViewBag.IdBrand = new SelectList(Data.GetCatBrands(), "IdBrand", "Code", products.IdBrand);
            ViewBag.IdCatalog = new SelectList(Data.GetCatCatalogs(), "IdCatalog", "Season", products.IdCatalog);
            ViewBag.IdColor = new SelectList(Data.GetCatColors(), "IdColor", "Name", products.IdColor);
            ViewBag.IdProvider = new SelectList(Data.GetCatProviders(), "IdProvider", "Name", products.IdProvider);
            ViewBag.IdType = new SelectList(Data.GetCatTypeProduct(), "IdType", "Code", products.IdType);
            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = Business.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = Business.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = Business.Find(id);
            Business.Delete(products);
            return RedirectToAction("Index");
        }

        public ActionResult FileUpload([Bind(Include = "Id")]Products pro, HttpPostedFileBase file)
        {
            string pic = System.IO.Path.GetFileName(file.FileName);
            if (file != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                    Business.AddImage(array,pro.Id); //id
                }
            }
            return RedirectToAction("Edit", "Product",new {id = pro.Id });
        }
    }
}