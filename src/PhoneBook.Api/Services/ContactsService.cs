using PhoneBook.Api.Commands;
using PhoneBook.Api.DTO;
using PhoneBook.Api.Entities;
using System.Linq;

namespace PhoneBook.Api.Services
{
    public class ContactsService
    {
        private readonly static List<Contact> Contacts = new();

        public ContactDto Get(int number)
        {
            var contact = Contacts.SingleOrDefault(x => x.Number == number);
            if(contact is null)
            {
                return default;
            }
            return new ContactDto()
            {
                Name = contact.Name,
                Surname = contact.Surname,
                Number = contact.Number
            };
        }

        public ContactDto GetByName(string name)
        {
            var contacts = Contacts.SingleOrDefault(x => x.Name == name);

            if(contacts is null)
            {
                return default;
            }

            return new ContactDto()
            {
                Name = contacts.Name,
                Surname = contacts.Surname,
                Number = contacts.Number
            };
        }

        public IEnumerable<Contact> GetAll() => Contacts;

        public int? Create(CreateContact command)
        {
            var isContactExist = Contacts.Any(x => x.Number == command.Number);

            if(isContactExist)
            {
                return default;
            }

            var contact = new Contact(command.Name, command.Surname, command.Number);
            Contacts.Add(contact);
            return contact.Number;
        }
    }
}
