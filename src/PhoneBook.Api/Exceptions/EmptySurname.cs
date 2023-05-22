namespace PhoneBook.Api.Exceptions
{
    public sealed class EmptySurname : PhoneBookException
    {
        public EmptySurname() : base("Contact surname is empty.")
        {

        }
    }
}
