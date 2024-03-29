﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Employee.Domain.Repositories.Base;
using Employee.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Employee.Persistence.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly EmployeeContext _employeeContext;

        public Repository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _employeeContext.Set<T>().AddAsync(entity);
            await _employeeContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _employeeContext.Set<T>().Remove(entity);
            await _employeeContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _employeeContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _employeeContext.Set<T>().FindAsync(id);
        }

        public Task UpdateAsync(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
