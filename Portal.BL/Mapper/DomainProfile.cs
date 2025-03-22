using AutoMapper;
using Portal.BL.ModelVM.Departments;
using Portal.BL.ModelVM.Employees;

namespace Portal.BL.Mapper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            
            CreateMap<Employee, GetAllEmployeeVM>()
    .ForMember(dest => dest.DepartmentsName, opt => opt.MapFrom(src => src.Dept.Name)).ReverseMap();

            CreateMap<Department, GetAllDepartmnetVM>();


        }
    }
}
