using PhoneBook.Api.Exceptions;
using System.Xml.Linq;

namespace PhoneBook.Api.ValueObjects
{
    public record Name
    {
        public string Value { get; }

        public Name(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyContactName();
            }

            if (value.Length < 3)
            {
                throw new ToShortContactName(value);
            }

            Value = value;
        }

        public static implicit operator string (Name name) => name?.Value;
        public static implicit operator Name(string name) => new(name);
    }
}
