﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeePortal.Areas.Identity.Data.Employee
{
    [Table("SPOct2023")]
    public class EmployeeEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string? LocationName { get; set; }
        public string? DepartmentName { get; set; }
        public string? CategoryName { get; set; }
        public string? SubCategoryName { get; set; }
        public string? E1 { get; set; }
        public string? E2 { get; set; }
        public string? M1 { get; set; }
        public float? C { get; set; }
        public string? M2 { get; set; }
    }
}
