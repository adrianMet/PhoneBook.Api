using PhoneBook.Api.Exceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PhoneBook.Api.ValueObjects
{
    public record Number
    {
        public int Value { get; }

        public Number(int value)
        {
            if (value.ToString().Length != 9)
            {
                throw new WrongNumberFormat(value);
            }

            Value = value;
        }

        public static implicit operator int(Number number) => number.Value;
        public static implicit operator Number(int number) => new(number);
    }
}
