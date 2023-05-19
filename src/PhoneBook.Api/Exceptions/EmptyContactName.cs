namespace PhoneBook.Api.Exceptions
{
    public sealed class EmptyContactName : PhoneBookException
    {
        public EmptyContactName() : base("Contact name is empty.")
        {

        }
    }
}
