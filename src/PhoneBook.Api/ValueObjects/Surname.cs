namespace PhoneBook.Api.ValueObjects
{
    public sealed record Surname(string Value)
    {
        public string Value { get; } = Value;

        public static implicit operator string(Surname surname) => surname.Value;
        public static implicit operator Surname(string value) => new(value);
    }
}
