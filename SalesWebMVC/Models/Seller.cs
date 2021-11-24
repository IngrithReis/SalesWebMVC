using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name{ get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name ="Data de nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Base Salarial")]
        [DisplayFormat(DataFormatString ="{0:F2}")] // duas casas decimais 
        public double BaseSalary{ get; set; }

        [Display(Name = "Departamento")]
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
