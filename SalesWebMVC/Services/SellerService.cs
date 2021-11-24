using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using SalesWebMVC.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class SellerService
    { private readonly SalesWebMVCContext _contex;

        public SellerService(SalesWebMVCContext contex)
        {
            _contex = contex;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _contex.Seller.ToListAsync();
        }
        public async Task<Seller> FindByIdAsync(int id)
        {
            
            return await _contex.Seller.Include(obj => obj.Departament).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task InsertAsync(Seller seller)
        {
            
            _contex.Add(seller);
            await _contex.SaveChangesAsync();
            
        }
        public async Task RemoveAsync(int id)
        {
            try
            {
                var delete = await _contex.Seller.FindAsync(id);
                _contex.Seller.Remove(delete);
                await _contex.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException("Vendedor não pode ser deletado pois possui vendas");
            }
        }

        public async Task UpDateAsync(Seller seller)
        {   
             bool hasAny= await _contex.Seller.AnyAsync(x => x.Id == seller.Id);
            if (!hasAny)
            {
                throw new DllNotFoundException("Id não localizado");
            }
            try
            {
                _contex.Update(seller);
                await _contex.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e) // possível concorrência de excessão db
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }
        }

    }
}
