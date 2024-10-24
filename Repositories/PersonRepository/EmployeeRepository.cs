﻿using Microsoft.EntityFrameworkCore;
using REAgency.DAL.EF;
using REAgency.DAL.Entities.Person;
using REAgency.DAL.Interfaces;

namespace REAgency.DAL.Repositories.PersonRepository
{
    public class EmployeeRepository : IEmployee
    {
        private REAgencyContext db;

        public EmployeeRepository(REAgencyContext context)
        {
            this.db = context;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await db.Employees.Include(o => o.Post).ToListAsync();
        }

        public async Task<Employee> Get(int id)
        {
            var employees = await db.Employees.Include(o => o.Post).Where(a => a.Id == id).ToListAsync();
            Employee? employee = employees?.FirstOrDefault();
            return employee;
        }

        public async Task<Employee> GetByName(string name)
        {
            var employees = await db.Employees.Where(a => a.Name == name).ToListAsync();
            Employee? employee = employees?.FirstOrDefault();
            return employee;
        }

        public async Task Create(Employee employee)
        {
            await db.Employees.AddAsync(employee);
        }

        public void Update(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            Employee? employee = await db.Employees.FindAsync(id);
            if (employee != null)
                db.Employees.Remove(employee);
        }

    }
}
