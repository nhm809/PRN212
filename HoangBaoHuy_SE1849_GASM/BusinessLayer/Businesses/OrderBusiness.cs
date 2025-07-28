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
    public class OrderBusiness
    {
        private readonly OrderReposiroy orderReposiroy = new OrderReposiroy();
        public List<OrderDto> GetAll()
        {
            return orderReposiroy.GetAll()
                .Select(z => ToDto(z))
                .ToList();
        }
        public void Add(OrderDto dto)
        {
            orderReposiroy.Add(ToEntity(dto));
        }
        public void Update(OrderDto dto)
        {
            orderReposiroy.Update(ToEntity(dto, isUpdate: true));
        }
        public bool Delete(int deleteId)
        {
            return orderReposiroy.Delete(deleteId);
        }
        public List<OrderDto> Search(string keyword)
        {
            return orderReposiroy.Search(keyword)
                .Select(z => ToDto(z))
                .ToList();
        }
        private static Order ToEntity(OrderDto dto, bool isUpdate = false)
        {
            return new Order
            {
                OrderId = isUpdate ? dto.OrderId : 0,
                OrderAmount = dto.OrderAmount,
                OrderDate = dto.OrderDate,
                CustomerId = dto.CustomerId,
            };
        }

        private static OrderDto ToDto(Order x)
        {
            return new OrderDto
            {
                OrderId = x.OrderId,
                OrderAmount = x.OrderAmount,
                OrderDate = x.OrderDate,
                CustomerId = x.CustomerId,
                Name = x.Customer.Name,
                Email = x.Customer.Email,
                Password = x.Customer.Password,

            };
        }
    }
}
