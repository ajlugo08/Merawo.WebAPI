using Merawo.Core.Data;
using Merawo.Core.Models;
using Merawo.Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merawo.Core.Services
{
    public class ProductService : IProduct
    {
        private readonly MerawoContext _merawoContext;
        public ProductService(MerawoContext merawoContext)
        {
            _merawoContext = merawoContext;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            try
            {
                return await _merawoContext.Products
                       .Include(p => p.Brand)
                       .Include(p => p.Purchase)
                       .ThenInclude(p => p.Client)
                       .ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Product> GetById(int id)
        {
            try
            {
                return await _merawoContext.Products.FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
