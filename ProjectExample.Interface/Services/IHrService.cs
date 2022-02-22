using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectExample.Domain;

namespace ProjectExample.Interface.Services
{
    public interface IHrService
    {
        Task<List<HrDomain>> GetAll();
        Task<HrDomain> Get(int id);
        Task Add(HrDomain hrUser);
        Task Delete(int id);
    }
}