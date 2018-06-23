using Microsoft.AspNetCore.Hosting;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreMvcEvaluation.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(125)]
        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set;}
        [StringLength(25)]
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [StringLength(25)]
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [StringLength(25)]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Employee Type")]
        public virtual EmployeeType EmpType { get; set; }
        [StringLength(50)]
        [Display(Name = "Company Name")]
        public String CompanyName { get; set; }
        [Display(Name = "User is Active")]
        public bool IsActive { get; set; }
        [Display(Name = "Last Login")]
        public DateTime? LastLogin { get; set; }
        [Required]
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [Required]
        [Display(Name = "Created By")]
        public int CreatedBy { get; set; }

        public String getDisplayName()
        {
            String DisplayName = FirstName + " " + LastName;
            if (DisplayName.Length > 30) DisplayName = DisplayName.Substring(0, 27) + "...";
            return DisplayName;
        }
        public String getDisplayNameLastFirst()
        {
            String DisplayName = LastName + ", " + FirstName;
            if (DisplayName.Length > 30) DisplayName = DisplayName.Substring(0, 27) + "...";
            return DisplayName;
        }
    }
}