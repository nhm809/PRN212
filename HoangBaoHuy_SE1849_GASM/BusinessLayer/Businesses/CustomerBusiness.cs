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
    public class CustomerBusiness
    {
        private readonly CustomerRepository customerRepository = new CustomerRepository();
        public List<CustomerDto> GetAll()
        {
            return customerRepository.GetAll()
                .Select(z => ToDto(z))
                .ToList();
        }
        public void Add(CustomerDto dto)
        {
            customerRepository.Add(ToEntity(dto));
        }
        public void Update(CustomerDto dto)
        {
            customerRepository.Update(ToEntity(dto, isUpdate: true));
        }
        public bool Delete(int deleteId)
        {
            return customerRepository.Delete(deleteId);
        }
        public List<CustomerDto> Search(string keyword)
        {
            return customerRepository.Search(keyword)
                .Select(z => ToDto(z))
                .ToList();
        }
        private static Customer ToEntity(CustomerDto dto, bool isUpdate = false)
        {
            return new Customer
            {
                CustomerId = isUpdate ? dto.CustomerId : 0,
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
            };
        }

        private static CustomerDto ToDto(Customer x)
        {
            return new CustomerDto
            {
                CustomerId = x.CustomerId,
                Name = x.Name,
                Email = x.Email,
                Password = x.Password
            };
        }
    }
}
