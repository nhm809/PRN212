using BusinessLayer.Dtos;
using RepositoryLayer.Models;
using RepositoryLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Businesses
{
    public class CategoryBusiness
    {
        private readonly CategoryRepository categoryRepository = new CategoryRepository();
        public List<CategoryDto> GetAll()
        {
            return categoryRepository.GetAll()
                .Select(z => ToDto(z))
                .ToList();
        }
        public void Add(CategoryDto dto)
        {           
            categoryRepository.Add(ToEntity(dto));
        }
        public void Update(CategoryDto dto)
        {
            categoryRepository.Update(ToEntity(dto, isUpdate: true));
        }
        public bool Delete(int deleteId)
        {
            return categoryRepository.Delete(deleteId);
        }
        public List<CategoryDto> Search(string keyword)
        {
            return categoryRepository.Search(keyword)
                .Select(z => ToDto(z))
                .ToList();
        }
        private static Category ToEntity(CategoryDto dto, bool isUpdate = false)
        {
            return new Category
            {
                CategoryId = isUpdate ? dto.CategoryId : 0,
                Name = dto.Name,
                Picture = dto.Picture,
                Description = dto.Description,
            };
        }

        private static CategoryDto ToDto(Category x)
        {
            return new CategoryDto
            {
                CategoryId = x.CategoryId,
                Name = x.Name,
                Picture = x.Picture,
                Description = x.Description
            };
        }
    }
}
