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
        public void Insert(Seller seller)
        {
            _contex.Add(seller);
            _contex.SaveChanges();
            
        }
    }
}
