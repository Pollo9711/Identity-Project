using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectExample.Domain;

namespace ProjectExample.Interface.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeDomain>> GetAll();
        Task<EmployeeDomain> Get(int id);
        Task Add(EmployeeDomain employ);
        Task Delete(int id);
    }
}