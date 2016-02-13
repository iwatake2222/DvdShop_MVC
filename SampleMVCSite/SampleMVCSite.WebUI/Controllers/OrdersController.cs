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
    public class OrdersController : Controller
    {       
        IRepositoryBase<Order> orders;
        IRepositoryBase<OrderItem> orderItems;
        IRepositoryBase<Customer> customers;
        IRepositoryBase<Product> products;

        public OrdersController(IRepositoryBase<Order> orders, IRepositoryBase<OrderItem> orderItems, IRepositoryBase<Customer> customers, IRepositoryBase<Product> products)
        {
            this.orders = orders;
            this.orderItems = orderItems;
            this.customers = customers;
            this.products = products;
        }

        // GET: Orders
        public ActionResult Index()
        {
            var model = orders.GetAll();
            ViewBag.OrderItems = orderItems.GetAll();
            return View(model);
        }

        // GET: Orders/Details/5
        public ActionResult DetailsOrder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = orders.GetById(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult CreateOrder()
        {
            ViewBag.CustomerId = new SelectList(customers.GetAll(), "CustomerId", "CustomerName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder([Bind(Include = "OrderId,OrderDate,CustomerId,Status")] Order order)
        {
            if (ModelState.IsValid)
            {
                orders.Insert(order);
                orders.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(customers.GetAll(), "CustomerId", "CustomerName", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult EditOrder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = orders.GetById(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(customers.GetAll(), "CustomerId", "CustomerName", order.CustomerId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOrder([Bind(Include = "OrderId,OrderDate,CustomerId,Status")] Order order)
        {
            if (ModelState.IsValid)
            {
                orders.Update(order);
                orders.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(customers.GetAll(), "CustomerId", "CustomerName", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult DeleteOrder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = orders.GetById(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("DeleteOrder")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOrderConfirmed(int id)
        {
            orders.Delete(id);
            orders.Commit();
            return RedirectToAction("Index");
        }















        // GET: Orders/Details/5
        public ActionResult DetailsOrderItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItem orderItem = orderItems.GetById(id);
            if (orderItem == null)
            {
                return HttpNotFound();
            }
            return View(orderItem);
        }

        // GET: Orders/Create
        public ActionResult CreateOrderItem(int? orderId)
        {
            ViewBag.OrderId = new SelectList(orders.GetAll(), "OrderId", "OrderId", orderId);
            ViewBag.ProductId = new SelectList(products.GetAll(), "ProductId", "Title");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrderItem([Bind(Include = "OrderItemId,ProductId,UnitPrice,Quantity,OrderId")] OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                orderItems.Insert(orderItem);
                orderItems.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.OrderId = new SelectList(orders.GetAll(), "OrderId", "OrderId", orderItem.OrderId);
            ViewBag.ProductId = new SelectList(products.GetAll(), "ProductId", "Title", orderItem.ProductId);
            return View(orderItem);
        }

        // GET: Orders/Edit/5
        public ActionResult EditOrderItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItem orderItem = orderItems.GetById(id);
            if (orderItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderId = new SelectList(orders.GetAll(), "OrderId", "OrderId", orderItem.OrderId);
            ViewBag.ProductId = new SelectList(products.GetAll(), "ProductId", "Title", orderItem.ProductId);
            return View(orderItem);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOrderItem([Bind(Include = "OrderItemId,ProductId,UnitPrice,Quantity,OrderId")] OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                orderItems.Update(orderItem);
                orderItems.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.OrderId = new SelectList(orders.GetAll(), "OrderId", "OrderId", orderItem.OrderId);
            ViewBag.ProductId = new SelectList(products.GetAll(), "ProductId", "Title", orderItem.ProductId);
            return View(orderItem);
        }

        // GET: Orders/Delete/5
        public ActionResult DeleteOrderItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItem orderItem = orderItems.GetById(id);
            if (orderItem == null)
            {
                return HttpNotFound();
            }
            return View(orderItem);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("DeleteOrderItem")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOrderItemConfirmed(int id)
        {
            orderItems.Delete(id);
            orderItems.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                orders.Dispose();
                orderItems.Dispose();
            }
            base.Dispose(disposing);
        }
        
    }
}
