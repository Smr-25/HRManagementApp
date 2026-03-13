namespace HRManagementApplication.Exceptions
{
    public class EmployeeAlreadyExistsException : Exception
    {
        public EmployeeAlreadyExistsException(string message)
            : base(message)
        {
        }


    }
}

