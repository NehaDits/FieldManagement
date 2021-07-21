
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
    }
}
