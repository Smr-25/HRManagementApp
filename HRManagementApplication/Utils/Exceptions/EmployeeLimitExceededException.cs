namespace HRManagementApplication.Exceptions
{
    public class EmployeeLimitExceededException : Exception
    {
        public EmployeeLimitExceededException(string message)
            : base(message)
        {
        }


    }
}
