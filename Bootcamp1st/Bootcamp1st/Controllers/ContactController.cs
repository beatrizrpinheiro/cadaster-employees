using Bootcamp1st.Interfaces;
using Bootcamp1st.Models;
using Bootcamp1st.Services;
using Microsoft.AspNetCore.Mvc;


namespace Bootcamp1st.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost("contacts")]
        public IActionResult PostProducts(Contact newContact)
        {
            var contacts = _contactService.CreateContact(newContact);
            return Ok(contacts);
        }

       /* [HttpGet("contacts")]
        public IActionResult GetProductByEmail(string email) 
        {
            var contacts = _contactService.SearchContactByEmail(email);
            return Ok(contacts);
        }*/

        [HttpGet("contacts")]
        public IActionResult GetProduct()
        {
            var contacts = _contactService.SearchContact();
            return Ok(contacts);
        }

        /*[HttpGet("contacts")]
        public IActionResult GetProductByPosition(string position)
        {
            var contacts = _contactService.SearchContactByPosition(position);
            return Ok(contacts);
        }*/

        [HttpPut("contacts/{id:int}")]

        public IActionResult UpdateProduct(int id, Contact updateContact)
        {
            var contacts = _contactService.UpdateContact(id, updateContact);
            return Ok(contacts);
        }

        [HttpDelete("contacts/{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            var contacts = _contactService.DeleteContact(id);
            return Ok(contacts);
        }
        
    }
}
