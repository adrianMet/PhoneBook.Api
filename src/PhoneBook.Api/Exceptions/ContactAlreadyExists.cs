namespace PhoneBook.Api.Exceptions
{
    public sealed class ContactAlreadyExists : PhoneBookException
    {
        public ContactAlreadyExists() : base("Contact already exists.")
        {

        }
    }
}
