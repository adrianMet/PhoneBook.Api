using Microsoft.AspNetCore.Mvc;
using PhoneBook.Api.Entities;
using PhoneBook.Api.Services;

namespace PhoneBook.Api.Controllers
{
    [ApiController]
    [Route(template:"searchbyname")]
    public class ContactsSearchByName : ControllerBase
    {
        private readonly ContactsService _contactsService = new();

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
    }
}
