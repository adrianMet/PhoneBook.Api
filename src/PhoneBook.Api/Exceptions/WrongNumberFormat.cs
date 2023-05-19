namespace PhoneBook.Api.Exceptions
{
    public sealed class WrongNumberFormat : PhoneBookException
    {
        public WrongNumberFormat() : base("Contact number format is incorrect.")
        {

        }
    }
}
