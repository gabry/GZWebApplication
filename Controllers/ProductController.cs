using GZWebApplication.Filters;
using GZWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GZWebApplication.Controllers
{
    public class ProductsController : ApiController
    {
        static List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 8 },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 950000 }
        };
        
        public IHttpActionResult GetAllProducts()
        {
            return Ok(products);
        }

        public IHttpActionResult GetProductById(int? id)
        {
            if (!id.HasValue)
                return null;

            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        public IHttpActionResult GetProductByStringFilter([FromUri] GZStringFilter name)
        {
            var product = products.FirstOrDefault((p) => p.Name == name.Value);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        public IHttpActionResult GetProductByComplexFilter([FromUri] ProductFilter filter)
        {
            try
            {
                List<Product> items = products;

                if (filter.FilterId != null && filter.FilterId.Value.HasValue)
                {
                    items = items.Where(p => p.Id == filter.FilterId.Value).ToList();
                }

                if (filter.Name != null && !string.IsNullOrWhiteSpace(filter.Name.Value))
                {
                    items = items.Where(p => p.Name == filter.Name.Value).ToList();
                }

                if (filter.Category != null && !string.IsNullOrWhiteSpace(filter.Category.Value))
                {
                    items = items.Where(p => p.Category == filter.Category.Value).ToList();
                }

                if (filter.Price != null && filter.Price.Value.HasValue)
                {
                    items = items.Where(p => p.Price == filter.Price.Value).ToList();
                }

                return Ok(items);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Post(Product item)
        {
            try
            {
                if (item == null)
                    throw new OperationCanceledException("Item not found");

                if (item.Id.HasValue == false)
                    throw new OperationCanceledException("Id not found");

                var product = products.FirstOrDefault((p) => p.Id == item.Id);

                if (product != null)
                    throw new OperationCanceledException($"Product with Id {item.Id} already exists!");

                products.Add(item);
                return Ok(item);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
