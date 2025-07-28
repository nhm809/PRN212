using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class ProductRepository
    {
        private readonly FuminiTikiSystemContext _context = new FuminiTikiSystemContext();
        public List<Product> GetAll()
        {
            return _context.Products
                .Include(z => z.Category)
                .Include(z => z.Order)
                .ToList();
        }
        public void Add(Product add)
        {
            add.ProductId = _context.Products.Any()
               ? _context.Products.Max(b => b.ProductId) + 1
               : 1;
            _context.Products.Add(add);
            _context.SaveChanges();
        }
        public bool Update(Product update)
        {
            var origin = _context.Products.FirstOrDefault(z => z.ProductId == update.ProductId);
            if (origin == null)
                return false;

            origin.Name = update.Name;
            origin.Price = update.Price;
            origin.Description = update.Description;
            origin.CategoryId = update.CategoryId;
            origin.OrderId = update.OrderId;

            _context.SaveChanges();
            return true;
        }
        public bool Delete(int deleteId)
        {
            var origin = _context.Products.FirstOrDefault(z => z.ProductId == deleteId);
            if (origin == null)
                return false;

            _context.Products.Remove(origin);
            _context.SaveChanges();
            return true;
        }

        public List<Product> Search(string keyword)
        {
            keyword = keyword.ToLower();
            return _context.Products
                           .Include(z => z.Category)
                           .Where(r => r.Name.ToLower().Contains(keyword) ||
                                   r.Description.ToLower().Contains(keyword))
                           .ToList();
        }
    }
}
