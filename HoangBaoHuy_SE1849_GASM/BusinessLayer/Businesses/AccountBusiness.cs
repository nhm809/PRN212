using BusinessLayer.Dtos;
using RepositoryLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Businesses
{
    public class AccountBusiness
    {
        private readonly CustomerRepository customerRepository = new CustomerRepository();
        public CustomerDto? Login(string email, string password)
        {
            return customerRepository.GetAll()
                .Select(z => new CustomerDto
                {
                    CustomerId = z.CustomerId,
                    Name = z.Name,
                    Email = z.Email,
                    Password = z.Password
                })
                .FirstOrDefault(c => c.Email == email && c.Password == password);
        }
    }
}
