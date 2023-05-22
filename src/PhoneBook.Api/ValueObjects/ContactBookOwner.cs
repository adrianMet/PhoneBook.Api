namespace PhoneBook.Api.ValueObjects
{
    public record ContactBookOwner(string Value)
    {
        public string Value { get; } = Value;

        public static implicit operator string(ContactBookOwner ContactBookOwner) => ContactBookOwner.Value;
        public static implicit operator ContactBookOwner(string value) => new(value);
    }
}
