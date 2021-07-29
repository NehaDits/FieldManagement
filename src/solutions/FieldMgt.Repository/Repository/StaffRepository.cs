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
            try
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
                var details = new StaffListDTO()
                {
                    AlternatePhone = contactDetailModel.AlternatePhone,
                    AlternateEmail = contactDetailModel.AlternateEmail,
                    PrimaryPhone = contactDetailModel.PrimaryPhone,
                    CorrespondenceAddress = correspondenceAddressDetail.Address,
                    CorrespondenceCity = correspondenceAddressDetail.CityId,
                    CorrespondenceState = correspondenceAddressDetail.StateId,
                    CorrespondenceCountry = correspondenceAddressDetail.CountryId,
                    CorrespondenceZipCode = correspondenceAddressDetail.ZipCode,
                    DOB = staffModel.DOB,
                    PermanentAddress = permanentAddressDetail.Address,
                    PermanentCity = permanentAddressDetail.CityId,
                    PermanentState = permanentAddressDetail.StateId,
                    PermanentCountry = permanentAddressDetail.CountryId,
                    PermanentZipCode = permanentAddressDetail.ZipCode,
                    PrimaryEmail = contactDetailModel.PrimaryEmail,
                    FirstName = staffModel.FirstName,
                    LastName = staffModel.LastName,
                    Designation = staffModel.Designation,
                    Gender = staffModel.Gender,
                    StaffId = staffModel.StaffId
                    //map field names
                };
                return details;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }
        /// <summary>
        /// Get lsit of staff
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StaffListDTO> GetStaff() //=> _dbContext.Staffs.Where(a => a.IsDeleted == false).ToList();
        {
            try
            {
                IEnumerable<StaffListDTO> staffDetails = _dbContext.Staffs
                         .Join(_dbContext.AddressDetails, p => p.PermanentAddressId, pc => pc.AddressDetailId, (p, pc) => new { p, pc })
                         .Join(_dbContext.AddressDetails, a => a.p.CorrespondenceAddressId, ad => ad.AddressDetailId, (a, ad) => new { a, ad })
                         .Join(_dbContext.ContactDetails, cd => cd.a.p.ContactDetailId, c => c.ContactDetailId, (cd, c) => new { cd, c })
                         .Where(x => x.cd.a.p.IsActive == true)
                         .Select(m => new StaffListDTO
                         {
                             FirstName = m.cd.a.p.FirstName,
                             LastName = m.cd.a.p.LastName,
                             Gender = m.cd.a.p.Gender,
                             DOB = m.cd.a.p.DOB,
                             Designation = m.cd.a.p.Designation,
                             StaffId = m.cd.a.p.StaffId,
                             AlternateEmail = m.c.AlternateEmail,
                             PrimaryEmail = m.c.PrimaryEmail,
                             AlternatePhone = m.c.AlternatePhone,
                             PrimaryPhone = m.c.PrimaryPhone,
                             CorrespondenceAddress = m.cd.ad.Address,
                             CorrespondenceCity = m.cd.ad.CityId,
                             CorrespondenceCountry = m.cd.ad.CountryId,
                             CorrespondenceState = m.cd.ad.StateId,
                             CorrespondenceZipCode = m.cd.ad.ZipCode,
                             PermanentZipCode = m.cd.ad.ZipCode,
                             PermanentAddress = m.cd.ad.Address,
                             PermanentCity = m.cd.ad.CityId,
                             PermanentCountry = m.cd.ad.CountryId,
                             PermanentState = m.cd.ad.StateId
                         });
                return staffDetails;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }
        
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
