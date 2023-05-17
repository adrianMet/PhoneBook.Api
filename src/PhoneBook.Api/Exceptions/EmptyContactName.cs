namespace PhoneBook.Api.Exceptions
{
    public class EmptyContactName : PhoneBookException
    {
        public EmptyContactName() : base("Contact name is empty.")
        {

        }
    }
}
