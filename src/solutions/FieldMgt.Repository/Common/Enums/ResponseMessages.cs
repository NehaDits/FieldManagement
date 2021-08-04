
namespace FieldMgt.Repository.Enums
{
    public enum ResponseStatus
    {
        Success=1,
        Error,
        Warning,
        Info
    }
    public static class ResponseMessages
    {
        public static string RoleCreated = "Role Created Successfully";
        public static string RoleNotCreated = "Role not created";
        public static string RoleNotExit = "Role doesn't exist";
        public static string PasswordNotMatched = "Confirm Password doesn't match Password";
        public static string UserCreated = "User Created Successfully";
        public static string UserNotCreated = "User Not Created";
        public static string UserNotExist = "User Not Exist";
        public static string UserAccountIsDisable = "User has been disabled by the Admin";
        public static string InvalidPassword = "Invalid Password";
        public static string RoleNotAssignedToLogin = "User is not assigned a role to Login";
        public static string LeadContactNotExist = "Lead Contact doesnt exist";
        public static string LeadContactNotCreated = "Lead contact not created";
        public static string LeadNotFound = "Lead doesn't exist";
        public static string LeadNotCreated = "Lead can not be created";
        public static string UnableToCreateStaff = "Unable to create Staff";
        public static string StaffNotExist ="Staff Member doesnt exist";
        public static string UserNotDeleted = "User can not be deleted";
        public static string UserNotUpdated = "User can not be updated";
        public static string UserNotAuthorize = "You are not authorized";
        public static string UnknownError = "Some unknown error occoured";
        public static string ServiceProviderNotDeleted = "Service Provider can not be deleted";
        public static string ServicePRoviderNotUpdated = "Service Provider can not be updated";
        public static string ServiceProviderLocationNotDeleted = "Service Provider Location can not be deleted";
        public static string ServicePRoviderLocationNotUpdated = "Service Provider Location can not be updated";
    }
}
