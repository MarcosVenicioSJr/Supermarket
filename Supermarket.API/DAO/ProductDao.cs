using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Data;
using Supermarket.API.Mapper;
using Supermarket.API.Models;

namespace Supermarket.API.DAO
{
    public class ProductDao
    {
        private readonly DataContext _context;
        public ProductDao([FromServices] DataContext context) 
        {
            this._context = context;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            List<Product> produto = await _context.Products.AsNoTracking().ToListAsync();
            return produto;
        }
        public async Task<bool> ExistsProduct(string barCode)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync(x => x.BarCode == barCode);

            return product != null;
        }

        public async Task<Product> GetProductByBarCode(string barCode)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(x => x.BarCode == barCode);
            return product;
        }

        public async Task Save(Product product)
        {       
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
    }
}
