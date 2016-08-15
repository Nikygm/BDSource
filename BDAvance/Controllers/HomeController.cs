using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDAvance.DAL;
using BDAvance.Models;

namespace BDAvance.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult CheckOrders(OrderViewModel model)
        {
            var customer = _unitOfWork.CustomerRepository.GetById(model.CustomerIdCheck);
            if (customer == null)
            {
                ModelState.AddModelError("", "Wrong Id");
                return View("Index");
            }
            var orders = _unitOfWork.OrderRepository.Get(c => c.CustomerId.Equals(model.CustomerIdCheck), includeProperties: "ProductQuantities");
            var checkOrders = new CheckOrdersViewModel();
            checkOrders.Orders = new List<Order>();
            foreach (var o in orders)
            {
                checkOrders.Orders.Add(o);
            }
            return View(checkOrders);
        }

        public ActionResult NewOrder(OrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "A field is not correct");
                return View("Index");
            }
            var customer = _unitOfWork.CustomerRepository.GetById(model.CustomerId);
            if (customer == null)
            {
                ModelState.AddModelError("", "Wrong Id");
                return View("Index");
            }
            var currentOrderId = 1;
            if (_unitOfWork.OrderRepository.Get().Any())
            {
                var lastOrderId = _unitOfWork.OrderRepository.Get().Last().OrderId;
                currentOrderId = lastOrderId + 1;
            }
            
            _unitOfWork.OrderRepository.Insert(new Order { OrderId = currentOrderId, CustomerId = model.CustomerId});
            var listProd = new List<ProductQuantity>();
            listProd.Add(new ProductQuantity {OrderId = currentOrderId, ProductId = 1, Quantity = model.Abricot});
            listProd.Add(new ProductQuantity { OrderId = currentOrderId, ProductId = 2, Quantity = model.Banane });
            listProd.Add(new ProductQuantity { OrderId = currentOrderId, ProductId = 3, Quantity = model.Cerise });
            listProd.Add(new ProductQuantity { OrderId = currentOrderId, ProductId = 4, Quantity = model.Fraise });
            listProd.Add(new ProductQuantity { OrderId = currentOrderId, ProductId = 5, Quantity = model.Kiwi });
            listProd.Add(new ProductQuantity { OrderId = currentOrderId, ProductId = 6, Quantity = model.Framboise });
            listProd.Add(new ProductQuantity { OrderId = currentOrderId, ProductId = 7, Quantity = model.Groseille });
            listProd.Add(new ProductQuantity { OrderId = currentOrderId, ProductId = 8, Quantity = model.Prune });
            foreach (var p in listProd)
            {
                _unitOfWork.ProductQuantityRepository.Insert(p);
            }
            _unitOfWork.Save();
            return View(model);
        }
    }
}