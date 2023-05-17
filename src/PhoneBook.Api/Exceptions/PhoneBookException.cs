namespace PhoneBook.Api.Exceptions
{
    public abstract class PhoneBookException : Exception
    {
        protected PhoneBookException(string message) : base(message)
        {

        }
    }
}
