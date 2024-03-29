﻿using System.Threading;
using System.Threading.Tasks;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;

namespace FieldMgt.Core.Interfaces
{
    public interface IContactDetailRepository
    {
        Task<ContactDetail> SaveContactDetails(CreateContactDetailDTO model);
        void DeleteContact(int contactId, string deletedBy);
    }
}
