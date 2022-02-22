using System;
using ProjectExample.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectExample.Interface.Repositories;
using ProjectExample.Interface.Services;


namespace ProjectExample.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        
        public async Task Add(EmployeeDomain employ)
        {
            if (employ is null)
            {
                throw new Exception("user can't be null");
            }

            await _repository.Add(employ);
        }

        public async Task Delete(int id)
        {
            //if (_repository.Get(id) is null)
            //{
            //    throw new Exception("not found");
            //}

            await _repository.Delete(id);
        }

        public async Task<EmployeeDomain> Get(int id)
        {
            var employ = await _repository.Get(id);
            if (employ is null)
            {
                throw new Exception("employ not found");
            }

            return employ;
        }

        public async Task<List<EmployeeDomain>> GetAll()
        {
            return await _repository.GetAll();
        }

        public Task<EmployeeDomain> Update(EmployeeDomain employ)
        {
            throw new System.NotImplementedException();
        }
    }
}