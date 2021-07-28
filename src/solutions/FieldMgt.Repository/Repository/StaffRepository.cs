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
using AutoMapper;
using FieldMgt.Repository.AutoMapper;
using FieldMgt.Core.UOW;

namespace FieldMgt.Repository.Repository
{
    public class StaffRepository: GenericRepository<Staff>, IStaffRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUnitofWork _uow;
        private IMapper mapper;

        public StaffRepository(ApplicationDbContext dbContext, IUnitofWork uow, IMapper mapper) :base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _uow = uow;
        }


        /// <summary>
        /// Create the staff
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Staff> CreateStaffAsync(CreateEmployeeDTO model)
        {
            try
            {                 
                var staff = _mapper.Map<CreateEmployeeDTO, RegistrationDTO>(model);
                return await CommandAsync<Staff>(StoreProcedures.CreateStaff, staff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        /// <summary>
        /// Get the particular staff by his id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StaffListDTO GetStaffbyId(int id)
        {
            var staffModel = _dbContext.Staffs.Where(w =>
                  w.StaffId.Equals(id)).FirstOrDefault();
            var permanentAddressDetail = _dbContext.AddressDetails.Where(t =>
              t.AddressDetailId.Equals(staffModel.PermanentAddressId))
              .FirstOrDefault();
            var correspondenceAddressDetail = _dbContext.AddressDetails.Where(t =>
              t.AddressDetailId.Equals(staffModel.CorrespondenceAddressId))
              .FirstOrDefault();
            var contactDetailModel = _dbContext.ContactDetails.Where(p => p.ContactDetailId == staffModel.ContactDetailId)
              .FirstOrDefault();
            var details = (from master in _dbContext.Staffs
                           join detail in _dbContext.AddressDetails
                           on master.PermanentAddressId equals detail.AddressDetailId
                           where master.StaffId == id
                           from proj in _dbContext.ContactDetails where proj.ContactDetailId == master.ContactDetailId
                           select new StaffListDTO()
                           {
                               AlternatePhone = proj.AlternatePhone,
                               AlternateEmail = proj.AlternateEmail,
                               PrimaryPhone = contactDetailModel.PrimaryPhone,
                               CorrespondenceAddress = correspondenceAddressDetail.Address,
                               CorrespondenceCity = correspondenceAddressDetail.CityId,
                               CorrespondenceState = correspondenceAddressDetail.StateId,
                               CorrespondenceCountry = correspondenceAddressDetail.CountryId,
                               CorrespondenceZipCode = correspondenceAddressDetail.ZipCode,
                               DOB = master.DOB,
                               PermanentAddress = detail.Address,
                               PermanentCity = detail.CityId,
                               PermanentState = detail.StateId,
                               PermanentCountry = detail.CountryId,
                               PermanentZipCode = detail.ZipCode,
                               PrimaryEmail = proj.PrimaryEmail,
                               FirstName = master.FirstName,
                               LastName = master.LastName,
                               Designation = master.Designation,
                               Gender = master.Gender
                               //map field names
                           }).FirstOrDefault();
            return details;
        }
        /// <summary>
        /// Get lsit of staff
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Staff> GetStaff() => _dbContext.Staffs.Where(a => a.IsDeleted == false).ToList();
        
        /// <summary>
        /// soft delete staff when deleting User Account by User Id
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="deletedBy"></param>
        /// <returns></returns>
        public Staff DeleteStaffAsUser(string  userID, string deletedBy)
        {
            try
            {
                var currentStaff = _dbContext.Staffs.SingleOrDefault(a => a.UserId == userID);
                currentStaff.IsDeleted = true;
                currentStaff.DeletedBy = deletedBy;
                currentStaff.DeletedOn = System.DateTime.Now;
                int permanentAddress = (int)currentStaff.PermanentAddressId;
                int correspondenceAddress = (int)currentStaff.CorrespondenceAddressId;
                int contactDetail = (int)currentStaff.ContactDetailId;
                _uow.AddressRepositories.DeleteAddress(permanentAddress, deletedBy);
                _uow.AddressRepositories.DeleteAddress(correspondenceAddress, deletedBy);
                _uow.ContactDetailRepositories.DeleteContact(contactDetail, deletedBy);
                return Update(currentStaff);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }
        /// <summary>
        /// soft delete staff details when deleting by StaffId
        /// </summary>
        /// <param name="staffId"></param>
        /// <param name="deletedBy"></param>
        /// <returns></returns>
        public Staff DeleteStaff(int staffId, string deletedBy)
        {
            try
            {
                var currentStaff = _dbContext.Staffs.SingleOrDefault(a => a.StaffId == staffId);
                currentStaff.IsDeleted = true;
                currentStaff.DeletedBy = deletedBy;
                currentStaff.DeletedOn = System.DateTime.Now;
                int permanentAddress = (int)currentStaff.PermanentAddressId;
                int correspondenceAddress = (int)currentStaff.CorrespondenceAddressId;
                int contactDetail = (int)currentStaff.ContactDetailId;
                _uow.AddressRepositories.DeleteAddress(permanentAddress, deletedBy);
                _uow.AddressRepositories.DeleteAddress(correspondenceAddress, deletedBy);
                _uow.ContactDetailRepositories.DeleteContact(contactDetail, deletedBy);
                return Update(currentStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        /// <summary>
        /// update the staff detail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task UpdateStaffAsync(UpdateStaffDTO model) 
        { 
            try 
            {
                await CollectionsAsync<Task>(StoreProcedures.UpdateStaff, model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
}
        }
    }
}
