namespace HRManagementApp.Exceptions
{
    public class InvalidDepartmentNameException : Exception
    {
        public InvalidDepartmentNameException(string message) 
            : base(message)
        {
        }

    }
}
