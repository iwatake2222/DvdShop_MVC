using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SampleMVCSite.Contracts.Data;
using SampleMVCSite.Models;
using SampleMVCSite.Contracts.Repositories;

namespace SampleMVCSite.WebUI.Controllers
{
    public class CustomersController : Controller
    {
        IRepositoryBase<Customer> customers;

        public CustomersController(IRepositoryBase<Customer> customers)
        {
            this.customers = customers; 
        }

        // GET: Customers
        public ActionResult Index()
        {
            var model = customers.GetAll();
            return View(model);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = customers.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,CustomerName,Address1,Address2,Town,PostalCode,HomePhone,BusinessPhone,EmailAddress,CreditCardNumber,CreditCardType")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customers.Insert(customer);
                customers.Commit();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = customers.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,CustomerName,Address1,Address2,Town,PostalCode,HomePhone,BusinessPhone,EmailAddress,CreditCardNumber,CreditCardType")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customers.Update(customer);
                customers.Commit();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = customers.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            customers.Delete(id);
            customers.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                customers.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
