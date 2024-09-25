using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistration.Models
{
    public class Student
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        [Required(ErrorMessage ="Please Enter FirstName")]
        public string FirstName { get; set; }
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Please Enter Last Name")]
        public string LastName { get; set; }
        [DisplayName("Mother Name")]
        [Required(ErrorMessage = "Please Enter Mother Name")]
        public string MotherName { get; set; }
        [Required(ErrorMessage = "Please Select Gender")]
        public string Gender { get; set; }
        [DisplayName("Mobile Number")]
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        [DisplayName("Date Of Birth")]
        [Required(ErrorMessage = "Please Select Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        [DisplayName("Admission_Type")]
        [Required(ErrorMessage = "Please Enter Admission Type")]

        public string Admission_Type { get; set; }
        [DisplayName("Registration_Number")]
        [Required(ErrorMessage = "Please Enter Register Number")]
        public string Registration_Number { get; set; }
        [DisplayName("Ranking")]
        public string Ranking { get; set; }
        [DisplayName("Category")]
        public string Category { get; set; }
        [DisplayName("Branch")]
        [Required(ErrorMessage = "Please Enter Branch")]
        public string Branch { get; set; }
        [DisplayName("Admission_Year")]
        public string Admission_Year {  get; set; }
        
    }
}