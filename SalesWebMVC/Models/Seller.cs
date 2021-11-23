using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary{ get; set; }
        public Departament Departament { get; set; }
        public int DepartamentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
        public Seller()
        {
        }
        public Seller( string name, string email, DateTime birthDate, double baseSalary, Departament departament)
        {
           
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Departament = departament;
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Departament departament)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Departament = departament;
        }
        public void AddSales(SalesRecord salesRecord)
        {
            Sales.Add(salesRecord);
        }
        public void RemoveSales(SalesRecord salesRecord)
        {
            Sales.Remove(salesRecord);
        }
        public double AmountSales(DateTime dataInicial, DateTime dataFinal)
        {
            var amount = Sales.Where(s => s.Date >= dataInicial && s.Date <= dataFinal).Sum(a => a.Amount);
            return amount;
        }
    }
}
