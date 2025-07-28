using RepositoryLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class CategoryRepository
    {
        private readonly FuminiTikiSystemContext _context = new FuminiTikiSystemContext();
        public List<Category> GetAll()
        {
            return _context.Categories
                .ToList();
        }
        public void Add(Category add)
        {
            add.CategoryId = _context.Categories.Any()
               ? _context.Categories.Max(b => b.CategoryId) + 1
               : 1;
            _context.Categories.Add(add);
            _context.SaveChanges();
        }
        public bool Update(Category update)
        {
            var origin = _context.Categories.FirstOrDefault(z => z.CategoryId == update.CategoryId);
            if (origin == null)
                return false;

            origin.Name = update.Name;
            origin.Picture = update.Picture;
            origin.Description = update.Description;

            _context.SaveChanges();
            return true;
        }
        public bool Delete(int deleteId)
        {
            var origin = _context.Categories.FirstOrDefault(z => z.CategoryId == deleteId);
            if (origin == null)
                return false;

            _context.Categories.Remove(origin);
            _context.SaveChanges();
            return true;
        }
        public List<Category> Search(string keyword)
        {
            keyword = keyword.ToLower();
            return _context.Categories
                           .Where(r => r.Name.ToLower().Contains(keyword) ||
                                   r.Description.ToLower().Contains(keyword))
                           .ToList();
        }
    }
}
