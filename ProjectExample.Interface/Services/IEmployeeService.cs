using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectExample.Domain;

namespace ProjectExample.Interface.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDomain>> GetAll();
        Task<EmployeeDomain> Get(int id);
        Task Add(EmployeeDomain employ);
        Task Delete(int id);
    }
}