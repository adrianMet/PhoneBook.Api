using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Api.Entities;
using PhoneBook.Api.Services;

namespace PhoneBook.Api.Controllers
{
    [ApiController]
    [Route(template: "contacts")]
    public class ContactsController :ControllerBase
    {
        private readonly ContactsService _contactsService = new();

        [HttpGet]
        public ActionResult<IEnumerable<Contact>> Get() => Ok(_contactsService.GetAll());

        [HttpGet(template:"{number:int}")]
        public ActionResult<Contact> Get(int number)
        {
            var contact = _contactsService.Get(number);
            if(contact is null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost]
        public ActionResult Post(Contact contact)
        {
            var number = _contactsService.Create(contact);
            if(number is null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { number }, null);
        }
    }
}
