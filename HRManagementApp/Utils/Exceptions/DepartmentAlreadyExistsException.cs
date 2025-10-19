namespace HRManagementApp.Exceptions
{
    public class DepartmentAlreadyExistsException : Exception
    { 
        public DepartmentAlreadyExistsException(string message) 
            : base(message)
        {
        }

    }
}
