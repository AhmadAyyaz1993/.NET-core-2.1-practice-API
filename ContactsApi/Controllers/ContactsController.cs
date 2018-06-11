using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly DatabaseContext _context;


        public ContactsController(DatabaseContext context){
            _context = context;


        }

        // GET: api/values
        [HttpGet]
        public ActionResult<List<ContactItem>> GetAll()
        {
            return _context.ContactItems.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetContact")]
        public ActionResult<ContactItem> GetById(long id)
        {
            var item = _context.ContactItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
        // POST api/values
        [HttpPost]
        public IActionResult Create(ContactItem item)
        {
            _context.ContactItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetContact", new { id = item.Id }, item);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Update(long id, ContactItem item)
        {
            var contactItem = _context.ContactItems.Find(id);
            if(contactItem == null)
            {
                return NotFound();
            }
            contactItem.Address = item.Address;
            contactItem.PhoneNumber = item.PhoneNumber;
            contactItem.Name = item.Name;

            _context.ContactItems.Update(contactItem);
            _context.SaveChanges();

            return NoContent();
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var contactItem = _context.ContactItems.Find(id);
            if (contactItem == null)
            {
                return NotFound();
            }
            _context.ContactItems.Remove(contactItem);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
