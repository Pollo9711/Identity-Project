using System;
using ProjectExample.Domain;
using ProjectExample.Interface.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectExample.Context;
using ProjectExample.Context.Entities;

namespace ProjectExample.Repositories
{
    public class HrRepository : IHrRepository
    {
        private readonly ProjectExampleDbContext _context;
        private readonly IMapper _mapper;

        public HrRepository(ProjectExampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add(HrDomain hrUser)
        {
            var hrEntity = _mapper.Map<HrEntity>(hrUser);
            await _context.HrUsers.AddAsync(hrEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var hrUsers = await _context.HrUsers.FirstOrDefaultAsync(h => h.Id == id);
            _context.HrUsers.Remove(hrUsers);
            await _context.SaveChangesAsync();
        }

        public async Task<HrDomain> Get(int id)
        {
            var hrUser = await _context.HrUsers.FirstOrDefaultAsync(h => h.Id == id);
            if (hrUser is null)
            {
                throw new Exception("hrUser not found");
            }

            return _mapper.Map<HrDomain>(hrUser);

        }

        public async Task<List<HrDomain>> GetAll()
        {
            var hrUsers = await _context.HrUsers.ToListAsync();
            var test = _mapper.Map<List<HrDomain>>(hrUsers);
            return test;
        }

    }
}