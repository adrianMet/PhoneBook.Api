namespace PhoneBook.Api.Commands
{
    public record CreateContact(string Name, string Surname, int Number, string ContactBookOwner);

}
