using PhoneBook.Api.Commands;
using PhoneBook.Api.Exceptions;
using PhoneBook.Api.ValueObjects;

namespace PhoneBook.Api.Entities
{
    public class Contact
    {
        public Name Name { get; private set; }
        public Surname Surname { get; private set; }
        public Number Number { get; private set; }
        public ContactBookOwner ContactBookOwner { get; }
        public Contact(string name, string surname, int number, string contactBookOwner)
        {
            ChangeName(name);
            ChangeSurname(surname);
            ChangeNumber(number);
            ContactBookOwner = contactBookOwner;
        }

        public void ChangeName(Name name) => Name = name;

        public void ChangeNumber(Number number) => Number = number;
        public void ChangeSurname(Surname surname) => Surname = surname;
    }
}
