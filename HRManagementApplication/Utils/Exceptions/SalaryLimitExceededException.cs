namespace HRManagementApplication.Exceptions
{
    public class SalaryLimitExceededException : Exception
    {
        public SalaryLimitExceededException(string message)
            : base(message)
        {
        }

    }
}
