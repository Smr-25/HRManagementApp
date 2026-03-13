namespace HRManagementApplication.Exceptions
{
    public class InvalidEmployeePositionException : Exception
    {
        public InvalidEmployeePositionException(string message)
            : base(message)
        {
        }
    }
}
