using SampleMVCSite.Contracts.Repositories;
using SampleMVCSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SampleMVCSite.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        IRepositoryBase<Product> products;

        public ProductsController(IRepositoryBase<Product> products)
        { 
            this.products = products; 
        }
        // GET: Products
        public ActionResult Index(string keyword)
        {
            var model = products.GetAll();

            if (!string.IsNullOrEmpty(keyword))
            {
                var orgModel = model;
                model = orgModel.Where(q=>q.Title.Contains(keyword));
                model = model.Union(orgModel.Where(q => q.Description.Contains(keyword)));
            }
            foreach(var product in model){
                if(product.ImageUrl == null) product.ImageUrl="/Content/img/no_image.jpg";
            }
            return View(model);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = products.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Products1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,Title,Description,ImageUrl,Actors,Date,Price,CostPrice,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                products.Insert(product);
                products.Commit();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = products.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Products1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Title,Description,ImageUrl,Actors,Date,Price,CostPrice,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                products.Update(product);
                products.Commit();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = products.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Products1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            products.Delete(id);
            products.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                products.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}