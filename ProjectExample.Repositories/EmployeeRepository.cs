using System;
using ProjectExample.Domain;
using ProjectExample.Interface.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectExample.Context;
using ProjectExample.Context.Entities;

namespace ProjectExample.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ProjectExampleDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(ProjectExampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add(EmployeeDomain employ)
        {
            var employEntity = _mapper.Map<EmployeeEntity>(employ);
            _context.Employee.Add(employEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var employEntity = await _context.Employee.FirstOrDefaultAsync(e => e.Id == id);
            _context.Employee.Remove(employEntity);
            await _context.SaveChangesAsync();
        }


        public async Task<EmployeeDomain> Get(int id)
        {
            var employ = await _context.Employee.FirstOrDefaultAsync(e => e.Id == id);
            if (employ is null)
            {
                throw new Exception("employ not found");
            }
            return _mapper.Map<EmployeeDomain>(employ);
        }

        public async Task<List<EmployeeDomain>> GetAll()
        {
            var employEntities = _context.Employee;
            return await _mapper.ProjectTo<EmployeeDomain>(employEntities).ToListAsync();
        }

        
    }
}