using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DutchTreat.Data
{
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchContext _context;
        private readonly ILogger<DutchRepository> _logger;

        public DutchRepository(DutchContext context, ILogger<DutchRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            try
            {
                _logger.LogInformation("GetAllOrders was called");
                return _context.Orders
                    .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all orders {ex}");
                return null;
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("GetAllProduct was called");
                return _context.Products.OrderBy(p => p.Title).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products {ex}");
                return null;
            }

        }

        public Order GetOrderById(int id)
        {
            return _context.Orders
                  .Include(o => o.Items)
                  .ThenInclude(i => i.Product)
                  .Where(o => o.Id == id)
                  .FirstOrDefault();

            //return _context.Orders.Find(id); 

            //alttaki de listeliyor fakat ilini bulup orderi bulup getiriyor loopa girdigi icin orderitems gelmiyor o yuzden ilkini kullandim.

        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _context.Products.Where(p => p.Category == category).ToList();
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

    }
}
