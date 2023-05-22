using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
using PhoneBook.Api.Commands;
using PhoneBook.Api.DTO;
using PhoneBook.Api.Entities;
using PhoneBook.Api.Services;

namespace PhoneBook.Api.Controllers
{
    [ApiController]
    [Route("contacts")]
    public class ContactsController :ControllerBase
    {
        private readonly ContactsService _contactsService = new();

        [HttpGet]
        public ActionResult<IEnumerable<ContactDto>> Get() => Ok(_contactsService.GetAll());

        [HttpGet("{number:int}/{contactBookOwner}")]
        public ActionResult<ContactDto> Get(int number, string contactBookOwner)
        {
            var contact = _contactsService.Get(number, contactBookOwner);
            if(contact is null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpGet("{name}/{contactBookOwner}")]
        public ActionResult<ContactDto> GetByName(string name, string contactBookOwner)
        {
            var contacts = _contactsService.GetByName(name, contactBookOwner);
            if (contacts is null)
            {
                return NotFound();
            }

            return Ok(contacts);
        }

        [HttpPost]
        public ActionResult Post(CreateContact command)
        {
            var number = _contactsService.Create(command);
            if(number is null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { number }, null);
        }

        [HttpDelete("{number:int}/{contactBookOwner}")]
        public ActionResult Delete(DeleteContact command)
        {
            if (_contactsService.Delete(new DeleteContact(command.Number, command.contactBookOwner)))
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPut("{number:int}/{contactBookOwner}")]
        public ActionResult Update(int number, string contactBookOwner, UpdateContact command)
        {
            if(_contactsService.UpdateContact(number, contactBookOwner, new UpdateContact(command.Name, command.Surname, command.Number, command.contactBookOwner)))
            {
                return NoContent();
            }
            return NotFound();
        }

    }
}
