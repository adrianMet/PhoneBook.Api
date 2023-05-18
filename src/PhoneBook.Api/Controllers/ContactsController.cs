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

        [HttpGet("{number:int}")]
        public ActionResult<ContactDto> Get(int number)
        {
            var contact = _contactsService.Get(number);
            if(contact is null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpGet("{name}")]
        public ActionResult<ContactDto> GetByName(string name)
        {
            var contacts = _contactsService.GetByName(name);
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

        [HttpDelete("{number:int}")]
        public ActionResult Delete(int number) 
        {
            if(_contactsService.Delete(new DeleteContact(number)))
            {
                return NoContent();
            }

            return NotFound();
        }
        
    }
}
