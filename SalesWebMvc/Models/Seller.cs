using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }
        public Department Department { get; set; }  //implementação associando Seller com o Departament
        public int DepartmentId { get; set; } //garantindo pro entity framework que o pra ele garantir que esse Id vai ter que existir, uma vez q o tipo int não pode ser nulo
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>(); //associação do Seller com o SalesRecord

        public Seller()
        {
        }

        //inclui tds menos os atributos que são coleções
        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr) //operação pra adicionar uma venda na lista de vendas
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr) //operação pra remover uma venda na lista de vendas
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final) //operação pra implementar total de vendas do vendedor nesse período
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount); //link
        }
    }
}
