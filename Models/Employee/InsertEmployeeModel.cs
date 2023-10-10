﻿using System.ComponentModel.DataAnnotations;

namespace EmployeePortal.Models.Employee
{
    public class InsertEmployeeModel
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "The location name should have a maximum of 255 characters.")]
        [Display(Name = "LocationName")]
        public string LocationName { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "The department name should have a maximum of 255 characters.")]
        [Display(Name = "DepartmentName")]
        public string DepartmentName { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "The category name should have a maximum of 255 characters.")]
        [Display(Name = "CategoryName")]
        public string CategoryName { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "The sub category name should have a maximum of 255 characters.")]
        [Display(Name = "SubCategoryName")]
        public string SubCategoryName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The E1 should have a maximum of 50 characters.")]
        [Display(Name = "E1")]
        public string E1 { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The E2 should have a maximum of 50 characters.")]
        [Display(Name = "E2")]
        public string E2 { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The M1 should have a maximum of 50 characters.")]
        [Display(Name = "M1")]
        public string M1 { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The M2 should have a maximum of 50 characters.")]
        [Display(Name = "M2")]
        public string M2 { get; set; }
    }
}
