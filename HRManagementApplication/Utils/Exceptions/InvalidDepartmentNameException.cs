namespace HRManagementApplication.Exceptions
{
    public class InvalidDepartmentNameException : Exception
    {
        public InvalidDepartmentNameException(string message)
            : base(message)
        {
        }

    }
}
