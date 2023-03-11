using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace DutchTreat.Data
{
    public class DutchSeeder
    {
        private readonly DutchContext _context;
        private readonly IWebHostEnvironment _env;
        public DutchSeeder(DutchContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated(); //vt kontrolü

            if (!_context.Products.Any())
            {
                //need to create sample data
                var filePath = Path.Combine(_env.ContentRootPath, "Data/art.json");
                if (File.Exists(filePath))
                {
                    var json = File.ReadAllText(filePath);

                    // JsonSerializerOptions nesnesi oluştur
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    // JSON verisini dönüştür
                    var products = JsonSerializer.Deserialize<IEnumerable<Product>>(json, options);

                    _context.Products.AddRange(products);

                    var order = new Order()
                    {
                        OrderDate = DateTime.Today,
                        OrderNumber = "10000",
                        Items = new List<OrderItem>()
                        {
                            new OrderItem()
                            {
                                Product = products.First(),
                                Quantity= 5,
                                UnitPrice = products.First().Price
                            }
                        }
                    };
                    _context.SaveChanges();
                }
            }
        }
    }
}
