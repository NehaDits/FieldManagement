using FieldMgt.Repository.Enums;

namespace FieldMgt.Repository.Utils
{
    public static class Utilities
    {
        public static bool IsSuccess(string input) => input.Equals(ResponseStatus.Success);
        public static bool IsNotNull(object input)
        {
            return input != null;
        }
        public static bool IsNull(object input)
        {
            return input == null ;
        }
    }
}
