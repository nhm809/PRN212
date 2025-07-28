using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class OrderReposiroy
    {
        private readonly FuminiTikiSystemContext _context = new FuminiTikiSystemContext();
        public List<Order> GetAll()
        {
            return _context.Orders
                .Include(z => z.Customer)
                .ToList();
        }
        public void Add(Order add)
        {
            add.OrderId = _context.Orders.Any()
               ? _context.Orders.Max(b => b.OrderId) + 1
               : 1;
            _context.Orders.Add(add);
            _context.SaveChanges();
        }
        public bool Update(Order update)
        {
            var origin = _context.Orders.FirstOrDefault(z => z.OrderId == update.OrderId);
            if (origin == null)
                return false;

            origin.OrderAmount = update.OrderAmount;
            origin.OrderDate = update.OrderDate;
            origin.CustomerId = update.CustomerId;

            _context.SaveChanges();
            return true;
        }
        public bool Delete(int deleteId)
        {
            var origin = _context.Orders.FirstOrDefault(z => z.OrderId == deleteId);
            if (origin == null)
                return false;

            _context.Orders.Remove(origin);
            _context.SaveChanges();
            return true;
        }

        public List<Order> Search(string keyword)
        {
            keyword = keyword.ToLower();
            return _context.Orders
                           .Include(z => z.Customer)
                           .Where(r => r.Customer.Name.ToLower().Contains(keyword))
                           .ToList();
        }
    }
}
