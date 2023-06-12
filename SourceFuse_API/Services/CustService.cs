using System;
using System.Collections.Generic;
using Sourcefuse_Api.Models;
using Sourcefuse_Api.Data;

namespace Sourcefuse_Api.Services
{
    public class CustService
    {
        private readonly CustRepo _customerRepository;

        public CustService(CustRepo customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customerRepository.GetCustomers();
        }

        public Customer GetCustomer(int id)
        {
            return _customerRepository.GetCustomer(id);
        }

        public void CreateCustomer(Customer customer)
        {
            // Need to perform any business logic validations or modifications here before calling the repository
            _customerRepository.CreateCustomer(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            // Need to perform any business logic validations or modifications here before calling the repository
            _customerRepository.UpdateCustomer(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            // Need to perform any business logic validations or modifications here before calling the repository
            _customerRepository.DeleteCustomer(customer);
        }
    }
}
