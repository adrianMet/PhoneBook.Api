using PhoneBook.Api.Exceptions;

namespace PhoneBook.Api.ValueObjects
{
    public sealed record Surname
    {
        public string Value { get; }

        public Surname(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptySurname();
            }

            Value = value;
        }

        public static implicit operator string(Surname surname) => surname.Value;
        public static implicit operator Surname(string value) => new(value);
    }
}
