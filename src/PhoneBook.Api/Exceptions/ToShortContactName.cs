namespace PhoneBook.Api.Exceptions
{
    public sealed class ToShortContactName : PhoneBookException
    {
        public ToShortContactName(string value) : base($"Contact name {value} is to short.")
        {

        }
    }
}
