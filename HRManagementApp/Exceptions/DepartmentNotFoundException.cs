namespace HRManagementApp.Exceptions
{
    public class DepartmentNotFoundException : Exception
    {
        public DepartmentNotFoundException(string message)
            : base(message)
        {
        }
    }
}