using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectExample.Domain;

namespace ProjectExample.Interface.Repositories
{
    public interface IHrRepository 
    {
        Task<List<HrDomain>> GetAll();
        Task<HrDomain> Get(int id);
        Task Add(HrDomain hrUser);
        Task Delete(int id);
    }
}