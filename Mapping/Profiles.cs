using AutoMapper;
using EmployeePortal.Areas.Identity.Data.Employee;
using EmployeePortal.Models.Employee;

namespace EmployeePortal.Mapping
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<EmployeeEntity, InsertEmployeeRequest>();
            CreateMap<InsertEmployeeRequest, EmployeeEntity>();
            CreateMap<EmployeeEntity, ViewEmployeeModel>()
                .ForMember(e =>
                    e.Id, e => e.MapFrom(src => src.Id));
        }
    }
}
