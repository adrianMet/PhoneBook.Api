using PhoneBook.Api.Commands;
using PhoneBook.Api.DTO;
using PhoneBook.Api.Entities;
using System.Linq;

namespace PhoneBook.Api.Services
{
    public class ContactsService
    {
        private readonly static List<ContactBook> ContactBooks = new()
        {
            new ContactBook("B1")
        };

        public ContactDto Get(int number, string contactBookOwner)
        {
            var contact = ContactBooks.SelectMany(x => x.Contacts).SingleOrDefault(x => x.Number == number && x.ContactBookOwner == contactBookOwner);
            if(contact is null)
            {
                return default;
            }
            return new ContactDto()
            {
                Name = contact.Name,
                Surname = contact.Surname,
                Number = contact.Number,
                ContactBookOwner = contact.ContactBookOwner,
            };
        }

        public ContactDto GetByName(string name, string contactBookOwner)
        {
            var contacts = ContactBooks.SelectMany(x => x.Contacts).SingleOrDefault(x => x.Name == name && x.ContactBookOwner == contactBookOwner);

            if(contacts is null)
            {
                return default;
            }

            return new ContactDto()
            {
                Name = contacts.Name,
                Surname = contacts.Surname,
                Number = contacts.Number,
                ContactBookOwner = contacts.ContactBookOwner,
            };
        }

        public IEnumerable<ContactDto> GetAll() => ContactBooks.SelectMany(x => x.Contacts)
            .Select(x => new ContactDto
        {
            Name = x.Name,
            Surname = x.Surname,
            Number = x.Number,
            ContactBookOwner= x.ContactBookOwner,
        });

        public int? Create(CreateContact command)
        {
            var contactBook = ContactBooks.SingleOrDefault(x => x.ContactBookOwner == command.ContactBookOwner);
            var contact = new Contact(command.Name, command.Surname, command.Number, command.ContactBookOwner);
            contactBook.AddContact(contact);
            return contact.Number;
        }

        public bool Delete(DeleteContact command)
        {
            var contactBooks = GetContactBookByBookOwner(command.contactBookOwner);
            if (contactBooks is null)
            {
                return false;
            }

            var existingContact = contactBooks.Contacts.SingleOrDefault(x => x.ContactBookOwner == command.contactBookOwner && x.Number == command.Number);
            if (existingContact is null)
            {
                return false;
            }

            contactBooks.RemoveContact(existingContact);

            return true;
        }

        public bool UpdateContact(int number, string contactBookOwner, UpdateContact command)
        {
            var contactBooks = GetContactBookByBookOwner(contactBookOwner);
            if (contactBooks is null)
            {
                return false;
            }
            var existingContact = contactBooks.Contacts.SingleOrDefault(x => x.ContactBookOwner == contactBookOwner && x.Number == number);
            if (existingContact is null)
            {
                return false;
            }

            existingContact.ChangeSurname(command.Surname);
            existingContact.ChangeNumber(command.Number);
            existingContact.ChangeName(command.Name);
            return true;
        }

        private ContactBook GetContactBookByBookOwner(string contactBookOwner)
            => ContactBooks.SingleOrDefault(x => x.Contacts.Any(c => c.ContactBookOwner == contactBookOwner));

    }
}
