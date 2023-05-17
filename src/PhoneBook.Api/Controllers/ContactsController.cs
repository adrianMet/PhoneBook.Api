using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
using PhoneBook.Api.Entities;
using PhoneBook.Api.Services;

namespace PhoneBook.Api.Controllers
{
    [ApiController]
    public class ContactsController :ControllerBase
    {
        private readonly ContactsService _contactsService = new();

        [Route("SearchAll")]
        [HttpGet]
        public ActionResult<IEnumerable<Contact>> Get() => Ok(_contactsService.GetAll());

        [Route("SearchByNumber/{number}")]
        [HttpGet]
        public ActionResult<Contact> Get(int number)
        {
            var contact = _contactsService.Get(number);
            if(contact is null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [Route("SearchByName/{name}")]
        [HttpGet]
        public ActionResult<Contact> GetByName(string name)
        {
            var contacts = _contactsService.GetByName(name);
            if (contacts is null)
            {
                return NotFound();
            }

            return Ok(contacts);
        }

        [Route("AddContact")]
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
