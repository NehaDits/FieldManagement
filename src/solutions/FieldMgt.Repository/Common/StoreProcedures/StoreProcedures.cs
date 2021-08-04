namespace FieldMgt.Repository.Common.StoreProcedures
{
    public static class StoreProcedures
    {
        public static string SaveAddressDetail = "sp_SaveAddressDetail";
        public static string SaveContactDetail = "sp_SaveContactDetail";
        public static string SaveVendorDetail = "sp_InsertVendorDetail";
        public static string UpdateVendorDetail = "sp_UpdateVendorDetail";
        public static string CreateStaff = "sp_CreateStaffMember";
        public static string UpdateStaff = "sp_UpdateStaffMember";
        public static string CreateServiceProvider = "sp_CreateServiceProvider";
        public static string UpdateServiceProvider = "sp_UpdateServiceProvider";
        public static string CreateLead = "sp_CreateLead";
        public static string UpdateLead = "sp_UpdateLead";
        public static string UpdateLeadStatus = "sp_UpdateLeadStatus";
        public static string SaveClientInfo = "sp_SaveClientInfo";
        public static string CreateServiceProviderLocation = "sp_CreateServiceProviderLocation";
        public static string UpdateServiceProviderLocation = "sp_UpdateServiceProviderLocation";
    }
}
