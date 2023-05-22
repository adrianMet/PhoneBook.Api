namespace PhoneBook.Api.Commands
{
    public record UpdateContact(string Name, string Surname, int Number, string contactBookOwner);
}
