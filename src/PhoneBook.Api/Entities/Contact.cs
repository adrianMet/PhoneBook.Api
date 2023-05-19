﻿using PhoneBook.Api.Commands;
using PhoneBook.Api.Exceptions;

namespace PhoneBook.Api.Entities
{
    public class Contact
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int Number { get; private set; }
        public string ContactBookOwner { get; }
        public Contact(string name, string surname, int number, string contactBookOwner)
        {
            ChangeName(name);
            Surname = surname;
            ChangeNumber(number);
            ContactBookOwner = contactBookOwner;
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new EmptyContactName();
            }

            Name = name;
        }

        public void ChangeNumber(int number)
        {
            if (number.ToString().Length != 9)
            {
                throw new WrongNumberFormat();
            }

            Number = number;
        }
    }
}
