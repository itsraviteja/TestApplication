using System.Threading.Tasks;

namespace Test.Repository.IRepository
{
    public interface IDepartmentRepository
    {
        Task<DepartmemtModel> GetDepartmemtById();
        Task<DepartmemtModel> AddUpdateOrDeleteDepartmentDetailsAsync(string name);
    }
}
