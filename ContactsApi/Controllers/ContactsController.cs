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
        private readonly IDataRepository<ContactItem> _iRepo;   


        public ContactsController(IDataRepository<ContactItem> iRepo){
            _iRepo = iRepo;


        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<ContactItem> GetAll()
        {
            return _iRepo.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetContact")]
        public ContactItem GetById(long id)
        {
            var item = _iRepo.GetById(id);
            if (item == null)
            {
                return item;
            }
            return item;
        }
        // POST api/values
        [HttpPost]
        public ContactItem Create(ContactItem item)
        {
            var contactItem = _iRepo.Create(item);

            return contactItem;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ContactItem Update(long id, ContactItem item)
        {
            var contactItem = _iRepo.Update(id,item);
            if(contactItem == null)
            {
                return contactItem;
            }


            return contactItem;
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ContactItem Delete(long id)
        {
            var contactItem = _iRepo.Delete(id);
            if (contactItem == null)
            {
                return contactItem;
            }
           
            return contactItem;
        }
    }
}
