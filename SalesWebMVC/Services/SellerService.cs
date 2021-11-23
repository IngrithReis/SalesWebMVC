using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
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

        public List<Seller> FindAll()
        {
            return _contex.Seller.ToList();
        }
        public Seller FindById(int id)
        {
            
            return _contex.Seller.Include(obj => obj.Departament).FirstOrDefault(x => x.Id == id);
        }
        public void Insert(Seller seller)
        {
            
            _contex.Add(seller);
            _contex.SaveChanges();
            
        }
        public void Remove(int id)
        {
            var delete = _contex.Seller.Find(id);
            _contex.Seller.Remove(delete);
            _contex.SaveChanges();
        }

    }
}
