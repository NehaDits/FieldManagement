using FieldMgt.Repository.Enums;

namespace FieldMgt.Repository.Utils
{
    public static class Utilities
    {
        public static bool IsSuccess(string input) => input.Equals(ResponseMessages.Success);
    }
}
