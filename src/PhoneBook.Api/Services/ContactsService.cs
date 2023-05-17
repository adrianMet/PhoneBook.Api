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

        public IEnumerable<Contact> GetAll() => Contacts;

        public int? Create(Contact contact)
        {
            var isContactExist = Contacts.Any(x => x.Name == contact.Name && x.Number == contact.Number);

            if(isContactExist)
            {
                return default;
            }

            Contacts.Add(contact);
            return contact.Number;
        }
    }
}
