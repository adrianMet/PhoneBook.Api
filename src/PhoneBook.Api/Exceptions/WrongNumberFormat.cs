namespace PhoneBook.Api.Exceptions
{
    public sealed class WrongNumberFormat : PhoneBookException
    {
        public WrongNumberFormat(int value) : base($"Contact number {value} format is incorrect.")
        {

        }
    }
}
