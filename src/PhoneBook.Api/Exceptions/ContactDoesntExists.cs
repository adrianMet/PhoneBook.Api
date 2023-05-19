namespace PhoneBook.Api.Exceptions
{
    public sealed class ContactDoesntExists : PhoneBookException
    {
        public ContactDoesntExists() : base("Conctact is doeasn't exists.")
        {

        }
    }
}
