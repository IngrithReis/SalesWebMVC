using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMVCContext _context;
        public SalesRecordService(SalesWebMVCContext contex)
        {
            _context = contex;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? dataMinima, DateTime? dataMaxima)
        {
            var result = from obj in _context.SalesRecord select obj; // objeto construído para pesquisa

            if (dataMinima.HasValue)
            {
                result = result.Where(x => x.Date >= dataMinima.Value);
            }
            if(dataMaxima.HasValue)
            {
                result = result.Where(x => x.Date <= dataMaxima.Value);
            }
            return await result 
                .Include(x => x.Seller)
                .Include(x => x.Seller.Departament)
                .OrderByDescending(x=> x.Date)
                .ToListAsync();
        }
    }
}
