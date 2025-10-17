namespace HRManagementApp.Exceptions
{
    public class InvalidSalaryException : Exception
    {

        public InvalidSalaryException(string message) 
            : base(message)
        {
        }
    }
}
