using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Response;
using FieldMgt.Core.Interfaces;
using FieldMgt.Repository.UOW;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FieldMgt.Repository.Common.StoreProcedures;
using System;
using System.Threading;
using FieldMgt.Core.DTOs.Request;

namespace FieldMgt.Repository.Repository
{
    public class StaffRepository: GenericRepository<Staff>, IStaffRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public StaffRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Create the staff
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task CreateStaffAsync(CreateEmployeeDTO model)
        {
            try
            {
                await SingleAsync<Staff>(StoreProcedures.CreateStaff, model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        /// <summary>
        /// Get the particular staff by his id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Staff GetStaffbyId(int id) => GetById(id);

        /// <summary>
        /// Get lsit of staff
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Staff> GetStaff() => _dbContext.Staffs.Where(a => a.IsDeleted == true).ToList();

        /// <summary>
        /// soft delete staff
        /// </summary>
        /// <param name="staffId"></param>
        /// <param name="deletedBy"></param>
        /// <returns></returns>
        public Staff DeleteStaff(string staffId, string deletedBy)
        {
            var currentStaff = _dbContext.Staffs.SingleOrDefault(a => a.UserId == staffId);
            currentStaff.IsDeleted = true;
            currentStaff.DeletedBy = deletedBy;
            currentStaff.DeletedOn = System.DateTime.Now;
            return Update(currentStaff);
        }

        /// <summary>
        /// update the staff detail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Staff UpdateStaffAsync(Staff model) => Update(model);
    }
}
