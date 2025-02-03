namespace LegalexAccount.Utility.Exceptions
{
    public class ValidationException : Exception
    {
        public string WrongFieldName { get; set; } = string.Empty;


        public ValidationException(string fieldName, string message) : base(message)
        {
            WrongFieldName = fieldName;
        }
    }
}
