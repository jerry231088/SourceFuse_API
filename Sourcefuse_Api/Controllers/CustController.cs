using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sourcefuse_Api.Models;
using Sourcefuse_Api.Services;
using Sourcefuse_Api.ViewModels;

namespace Sourcefuse_Api.Controllers
{
    [ApiController]
    [Authorize(Policy = "ApiKeyPolicy")]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly CustService _customerService;

        public CustomerController(CustService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = _customerService.GetCustomers();
            var customerViewModels = customers.Select(c => MapToViewModel(c));
            return Ok(customerViewModels);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customer = _customerService.GetCustomer(id);
            if (customer == null)
                return NotFound();

            var customerViewModel = MapToViewModel(customer);
            return Ok(customerViewModel);
        }

        [HttpPost]
        public IActionResult CreateCustomer(CustomerVM customerViewModel)
        {
            var customer = MapToModel(customerViewModel);
            _customerService.CreateCustomer(customer);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, CustomerVM customerViewModel)
        {
            var customer = _customerService.GetCustomer(id);
            if (customer == null)
                return NotFound();

            MapToModel(customerViewModel, customer);
            _customerService.UpdateCustomer(customer);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _customerService.GetCustomer(id);
            if (customer == null)
                return NotFound();

            _customerService.DeleteCustomer(customer);
            return Ok();
        }

        private CustomerVM MapToViewModel(Customer customer)
        {
            return new CustomerVM
            {
                Id = customer.Id,
                Name = customer.Name,
                ContactInfo = new ContactInfoVM
                {
                    Email = customer.ContactInfo.Email,
                    Phone = customer.ContactInfo.Phone
                },
                Orders = customer.Orders.Select(o => new OrdersVM
                {
                    Id = o.Id,
                    OrderDate = o.OrderDate
                }).ToList()
            };
        }

        private Customer MapToModel(CustomerVM customerViewModel, Customer customer = null)
        {
            if (customer == null)
                customer = new Customer();

            customer.Id = customerViewModel.Id;
            customer.Name = customerViewModel.Name;
            customer.ContactInfo = new ContactInfo
            {
                Email = customerViewModel.ContactInfo.Email,
                Phone = customerViewModel.ContactInfo.Phone
            };
            // Handle Orders mapping

            return customer;
        }
    }
}
