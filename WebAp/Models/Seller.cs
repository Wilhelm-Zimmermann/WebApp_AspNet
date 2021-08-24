using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebAp.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(60,MinimumLength = 3,ErrorMessage = "{0} length should be between 3-60")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} is Required")]
        [EmailAddress(ErrorMessage = "Enter a valid Email")]
        public string Email { get; set; }

        [Display(Name="Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "{0} is Required")]
        public DateTime BirthDate { get; set; }

        [Display(Name="Base Salary")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        [Required(ErrorMessage = "{0} is Required")]
        [Range(100.0,50000.0,ErrorMessage = "{0} should be between {1} and {2}")]
        public double BasicSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller() { }

        public Seller(int id, string name, string email, DateTime birthDate, double basicSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BasicSalary = basicSalary;
            Department = department;
        }

        public void AddSale(SalesRecord sale)
        {
            Sales.Add(sale);
        }
        
        public void RemoveSale(SalesRecord sale)
        {
            Sales.Remove(sale);
        }

        public double TotalSales(DateTime initial , DateTime final)
        {
            return Sales.Where(x => x.Date >= initial && x.Date <= final).Sum(x => x.Amount);
        }
    }
}
