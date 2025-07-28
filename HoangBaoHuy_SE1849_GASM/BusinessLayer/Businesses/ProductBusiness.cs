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
    public class ProductBusiness
    {
        private readonly ProductRepository productRepository = new ProductRepository();
        public List<ProductDto> GetAll()
        {
            return productRepository.GetAll()
                .Select(z => ToDto(z))
                .ToList();
        }
        public void Add(ProductDto dto)
        {
            productRepository.Add(ToEntity(dto));
        }
        public void Update(ProductDto dto)
        {
            productRepository.Update(ToEntity(dto, isUpdate: true));
        }
        public bool Delete(int deleteId)
        {
            return productRepository.Delete(deleteId);
        }
        public List<ProductDto> Search(string keyword)
        {
            return productRepository.Search(keyword)
                .Select(z => ToDto(z))
                .ToList();
        }
        private static Product ToEntity(ProductDto dto, bool isUpdate = false)
        {
            return new Product
            {
                ProductId = isUpdate ? dto.ProductId : 0,
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description,
                CategoryId = dto.CategoryId,
            };
        }

        private static ProductDto ToDto(Product x)
        {
            return new ProductDto
            {
                ProductId = x.ProductId,
                Name = x.Name,
                Price = x.Price,
                Description = x.Description,
                CategoryId = x.CategoryId,
                Picture = x.Category.Picture
            };
        }
    }
}
