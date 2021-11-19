using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Data
{
    public class SeedingService
    {
        private SalesWebMVCContext _context;

        public SeedingService(SalesWebMVCContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            if (_context.Departament.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return; // testa se DB já foi populado
            }

            Departament d1 = new Departament( "Computers");
            Departament d2 = new Departament("Eletronics");
            Departament d5= new Departament("Fashion");
            Departament d4 = new Departament( "Books");

            Seller s1 = new Seller("Vanessa", "vanessa@teste",new DateTime(1980,10,1), 1000.00, d1);
            Seller s2 = new Seller( "Rodrigo Campos", "Roro@teste", new DateTime(1980, 10, 1), 1100.00, d2);
            Seller s3 = new Seller("Marieta", "Marimar@teste", new DateTime(1980, 10, 1), 1000.00, d1);
            Seller s4 = new Seller("Arnaldo Antunes", "Arnaldo@teste", new DateTime(1980, 10, 1), 2000.00, d4);
            Seller s5 = new Seller("Pablo", "Vitar@teste", new DateTime(1980, 10, 1), 1000.00, d5);
            Seller s6 = new Seller("Joana", "Jojo@teste", new DateTime(1980, 10, 1), 1350.00, d2);
            Seller s7 = new Seller( "Flavia", "Flafla@teste", new DateTime(1980, 10, 1), 1450.00, d4);
            Seller s8 = new Seller("Almir", "Almir@teste", new DateTime(1980, 10, 1), 1654.00, d1);

            SalesRecord r1 = new SalesRecord(new DateTime(2021,10,05), 400.00, Models.Enuns.SaleStatus.Billed, s3);
            SalesRecord r2 = new SalesRecord(new DateTime(2021, 10,03), 11000.00, Models.Enuns.SaleStatus.Billed, s1);
            SalesRecord r3 = new SalesRecord(new DateTime(2021,05,21), 25000.00, Models.Enuns.SaleStatus.Billed, s4);

            _context.Departament.AddRange(d1, d2, d5, d4);

            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6, s7, s8);

            _context.SalesRecord.AddRange(r1, r2, r3);

            _context.SaveChanges();

        }
    }
}
