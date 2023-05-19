using PhoneBook.Api.Exceptions;

namespace PhoneBook.Api.Entities
{
    public class ContactBook
    {
        private readonly HashSet<Contact> _contacts = new();
        public string ContactBookOwner { get; }
        public IEnumerable<Contact> Contacts => _contacts;

        public ContactBook(string contactBookOwner)
        {
            ContactBookOwner = contactBookOwner;
        }

        public void AddContact(Contact contact)
        {
            var contactAlreadyExists = Contacts.Any(x => x.Number == contact.Number);
            if (contactAlreadyExists)
            {
                throw new ContactAlreadyExists();
            }

            _contacts.Add(contact);
        }

        public void RemoveContact(Contact contact)
        {
            var isContactExists = Contacts.SingleOrDefault(x => x.Number == contact.Number && x.ContactBookOwner == contact.ContactBookOwner);

            if(isContactExists is null)
            {
                throw new ContactDoesntExists();
            }
            _contacts.Remove(contact);


        }
    }
}
