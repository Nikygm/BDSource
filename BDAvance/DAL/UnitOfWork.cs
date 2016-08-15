using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDAvance.Models;

namespace BDAvance.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly ProjectContext _context = new ProjectContext();
        private GenericRepository<Customer> _customerRepository;
        private GenericRepository<Product> _productRepository;
        private GenericRepository<Order> _orderRepository;
        private GenericRepository<ProductQuantity> _productQuantityRepository;

        //Return each repository on demand

        public GenericRepository<Customer> CustomerRepository =>_customerRepository ??
                                                                            (_customerRepository = new GenericRepository<Customer>(_context));
        public GenericRepository<Product> ProductRepository => _productRepository ??
                                                                    (_productRepository = new GenericRepository<Product>(_context));
        public GenericRepository<Order> OrderRepository => _orderRepository ??
                                                                    (_orderRepository = new GenericRepository<Order>(_context));
        public GenericRepository<ProductQuantity> ProductQuantityRepository => _productQuantityRepository ??
                                                                    (_productQuantityRepository = new GenericRepository<ProductQuantity>(_context));
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
