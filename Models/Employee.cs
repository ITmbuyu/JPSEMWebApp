using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JPSEMWebApp.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Enter Name of Employee")]
        public string EmpName { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Enter Surname")]
        public string EmpSurname { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Enter Email of Employee")]
        public string EmpEmail { get; set; }

        [Required]
        [Display(Name = "Enter Default Password ")]
        public string EmpPassword { get; set; }

        [Required]
        [StringLength(25)]
        public string EmployeeRole { get; set; }
    }
}
