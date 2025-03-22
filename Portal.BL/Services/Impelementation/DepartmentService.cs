
using AutoMapper;
using Portal.BL.ModelVM.Departments;

namespace Portal.BL.Services.Impelementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IMapper mapper;

        public DepartmentService(IDepartmentRepo departmentRepo,IMapper mapper )
        {
            DepartmentRepo=departmentRepo;
            this.mapper=mapper;
        }

        public IDepartmentRepo DepartmentRepo { get; }

        public List<GetAllDepartmnetVM> GetAll()
        {
            var depts = DepartmentRepo.GetAll();
            var result = mapper.Map<List<GetAllDepartmnetVM>>(depts);
            return result;
        }
    }
}
