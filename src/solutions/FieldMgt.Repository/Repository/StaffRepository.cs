﻿using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Response;
using FieldMgt.Core.Interfaces;
using FieldMgt.Repository.UOW;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace FieldMgt.Repository.Repository
{
    public class StaffRepository: GenericRepository<Staff>, IStaffRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public StaffRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateStaffAsync(Staff model) => await InsertAsync(model);
        public Staff GetStaffbyId(int id) => GetById(id);
        public IEnumerable<Staff> GetStaff() => _dbContext.Staffs.Where(a => a.IsDeleted == true).ToList();
        public Staff DeleteStaff(string staffId, string deletedBy)
        {
            var emp = _dbContext.Staffs.Where(a => a.UserId == staffId).Single();
            if (!(emp == null || emp.IsDeleted == true))
            {
                emp.IsDeleted = true;
                emp.DeletedBy = deletedBy;
                emp.DeletedOn = System.DateTime.Now;
                var emp1 = Update(emp);
                return emp;
            }
            return null;
        }
        public Staff UpdateStaffAsync(Staff model) => Update(model);
    }
}
