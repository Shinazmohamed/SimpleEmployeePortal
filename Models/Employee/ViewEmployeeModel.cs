using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmployeePortal.Models.Employee
{
    public class ViewEmployeeModel
    {
        public Guid Id { get; set; }
        [Display(Name = "LocationName")]
        public string LocationName { get; set; }
        [Display(Name = "DepartmentName")]
        public string DepartmentName { get; set; }
        [Display(Name = "CategoryName")]
        public string CategoryName { get; set; }
        [Display(Name = "SubCategoryName")]
        public string SubCategoryName { get; set; }
        [Display(Name = "E1")]
        public string E1 { get; set; }
        [Display(Name = "E2")]
        public string E2 { get; set; }
        [Display(Name = "M1")]
        public string M1 { get; set; }
        [Display(Name = "M2")]
        public string M2 { get; set; }
    }
}
