using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTech.DataAccess.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Full Name")]
        public string FullName { get; set; } = null!;
        [Column(TypeName = "varchar(10)")]
        [DisplayName ("Emp.Code")]
        public string EmpCode { get; set; } = null!;
        [Column(TypeName ="nvarchar(100)")]
        public string Position { get; set; } = null!;
        [Column(TypeName = "nvarchar (100)")]
        [DisplayName ("Office Location")]
        public string OfficeLocation { get; set; } = null!; 

    }
}
