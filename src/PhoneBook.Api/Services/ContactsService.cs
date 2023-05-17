using PhoneBook.Api.Entities;

namespace PhoneBook.Api.Services
{
    public class ContactsService
    {
        private readonly static List<Contact> Contacts = new();

        public Contact Get(int number)
        {
            var contact = Contacts.SingleOrDefault(x => x.Number == number);
            if(contact is null)
            {
                return default;
            }
            return contact;
        }

        public Contact GetByName(string name)
        {
            var contacts = Contacts.SingleOrDefault(x => x.Name == name);

            if(contacts is null)
            {
                return default;
            }

            return contacts;
        }

        public IEnumerable<Contact> GetAll() => Contacts;

        public int? Create(Contact contact)
        {
            var isContactExist = Contacts.Any(x => x.Number == contact.Number);

            if(isContactExist)
            {
                return default;
            }

            Contacts.Add(contact);
            return contact.Number;
        }
    }
}
