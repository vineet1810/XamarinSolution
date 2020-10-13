namespace Academy.UtilityAndModels
{
    public class Enums
    {
        public enum Gender
        {
            Male = 1,
            Female = 2,
            Other = 0
        }

        public enum UserRole
        {
            Admin = 1,
            Student = 2,
        }

        public enum ErrorCode
        {
            OK = 200,
            InValidData = 500,
            Error = 0
        }
    }
}
