namespace PhoneBook.Api.Exceptions
{
    public class WrongNumberFormat : PhoneBookException
    {
        public WrongNumberFormat() : base("Contact number format is incorrect.")
        {

        }
    }
}
