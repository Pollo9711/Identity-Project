using System;
using ProjectExample.Domain;
using ProjectExample.Interface.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectExample.Interface.Repositories;

namespace ProjectExample.Service
{
    public class HrService : IHrService
    {
        private readonly IHrRepository _repository;

        public HrService(IHrRepository repository)
        {
            _repository = repository;
        }
        public async Task Add(HrDomain hrUser)
        {
            if (hrUser is null)
            {
                throw new Exception("user can't be null");
            }
            await _repository.Add(hrUser);
        }

        public async Task Delete(int id)
        {
            if (_repository.Get(id) is null)
            {
                throw new Exception("not found");
            }
            await _repository.Delete(id);
        }

        public async Task<HrDomain> Get(int id)
        {
            var hrUser = await _repository.Get(id);
            if (hrUser is null)
            {
                throw new Exception("employ not found");
            }

            return hrUser;
        }

        public async Task<List<HrDomain>> GetAll()
        {
            return await _repository.GetAll();
        }

        public Task<HrDomain> Update(HrDomain hrUser)
        {
            throw new System.NotImplementedException();
        }
    }
}