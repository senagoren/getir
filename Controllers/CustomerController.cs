using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomerWebApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ILogger<CustomerController> _logger;
        private readonly Models.CustomerContext _context;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets All Customers ınformation
        /// </summary>
        /// <returns>All Customer list</returns>
        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = _context.Customers.ToList();
            return Ok(customers);
        }


        /// <summary>
        /// Gets Customer information which has input id
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns>Customer Information</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Customer>> GetCustomer(long id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }


        /// <summary>
        /// Creates new customer
        /// </summary>
        /// <param name="customer">New Customer Information</param>
        /// <returns>New Customer</returns>
        [HttpPost]
        public async Task<ActionResult<Models.Customer>> PostCustomer(Models.Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }



        /// <summary>
        /// Updates customer informations
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <param name="customer">Updated Customer Info</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(long id, Models.Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool CustomerExists(long id)
        {
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets order wihch has input id
        /// </summary>
        /// <param name="id">Order Id</param>
        /// <returns>Order</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Order>> GetOrder(long id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        /// <summary>
        /// Creates new order and update stocks
        /// </summary>
        /// <param name="order">New Order</param>
        /// <returns>New Order</returns>
        [HttpPost]
        public async Task<ActionResult<Models.Order>> PostOrder(Models.Order order)
        {
            _context.Orders.Add(order);
            var stock = _context.Stocks.Where(e => e.ProductId == order.ProductId).SingleOrDefault();
            stock.NumberOfProduct--;
            _context.Entry(stock).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        /// <summary>
        /// Gets All Orders by customer id 
        /// </summary>
        /// <returns>Customer's orders</returns>
        [HttpGet]
        public IActionResult GetOrders(long customerId)
        {
            var orders = _context.Orders.Where(e => e.CustomerId == customerId).ToList();
            return Ok(orders);
        }

        /// <summary>
        /// Gets product stocks by rpoduct ıd
        /// </summary>
        /// <returns>Products stocks</returns>
        [HttpGet]
        public IActionResult GetProductStocks(long productId)
        {
            var stocks = _context.Stocks.Where(e => e.ProductId == productId).ToList();
            return Ok(stocks);
        }
    }
}
