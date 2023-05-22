using PhoneBook.Api.Entities;
using PhoneBook.Api.Exceptions;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PhoneBook.Tests.Unit.Entities
{
    public class ContactBookTests
    {
        [Fact]
        public void given_existing_contact_add_contact_should_fail()
        {
            // ARRANGE
            _contactBook.AddContact(_contact);

            // ACT
            var exception = Record.Exception(() => _contactBook.AddContact(_contact));

            // ASSERT

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ContactAlreadyExists>();
        }

        [Fact]
        public void given_not_existing_contact_remove_contact_should_fail()
        {
            var exception = Record.Exception(() => _contactBook.RemoveContact(_contact));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ContactDoesntExists>();
        }

        [Fact]
        public void given_not_existing_contact_add_contact_should_succeed()
        {
            _contactBook.AddContact(_contact);

            _contactBook.Contacts.ShouldHaveSingleItem();
        }

        [Fact]
        public void given_existing_contact_remove_contact_should_succeed()
        {
            _contactBook.AddContact(_contact);

            _contactBook.RemoveContact(_contact);

            _contactBook.Contacts.ShouldBeEmpty();
        }

        private readonly ContactBook _contactBook;
        private readonly Contact _contact;
        public ContactBookTests()
        {
            _contactBook = new ContactBook("B1");
            _contact = new Contact("John", "Lock", 123456789, "B1");
        }
    }
}
