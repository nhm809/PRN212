using RepositoryLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class CustomerRepository
    {
        private readonly FuminiTikiSystemContext _context = new FuminiTikiSystemContext();
        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }      
        public void Add(Customer add)
        {
            add.CustomerId = _context.Customers.Any()
               ? _context.Customers.Max(b => b.CustomerId) + 1
               : 1;
            _context.Customers.Add(add);
            _context.SaveChanges();
        }
        public bool Update(Customer update)
        {
            var origin = _context.Customers.FirstOrDefault(z => z.CustomerId == update.CustomerId);
            if (origin == null)
                return false;

            origin.Name = update.Name;
            origin.Email = update.Email;
            origin.Password = update.Password;

            _context.SaveChanges();
            return true;
        }
        public bool Delete(int deleteId)
        {
            var origin = _context.Customers.FirstOrDefault(z => z.CustomerId == deleteId);
            if (origin == null)
                return false;

            _context.Customers.Remove(origin);
            _context.SaveChanges();
            return true;
        }
        public List<Customer> Search(string keyword)
        {
            keyword = keyword.ToLower();
            return _context.Customers
                           .Where(r => r.Name.ToLower().Contains(keyword) ||
                                   r.Email.ToLower().Contains(keyword))
                           .ToList();
        }
    }
}
