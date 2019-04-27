using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsApi.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize] 
        public IEnumerable<ContactItem> GetAll()
        {
            return _iRepo.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetContact")]
        [Authorize]
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
        [Authorize]
        public ContactItem Create(ContactItem item)
        {
            var contactItem = _iRepo.Create(item);

            return contactItem;
        }

        // PUT api/values/5
        [HttpPut]
        [Authorize]
        public ContactItem Update(ContactItem item)
        {
            var item2 = _iRepo.GetById(item.Id);
            if (item2 == null)
            {
                return item2;
            }
            item2.Address = item.Address;
            item2.PhoneNumber = item.PhoneNumber;
            item2.Name = item.Name;

            var contactItem = _iRepo.Update(item2);
            if(contactItem == null)
            {
                return contactItem;
            }


            return contactItem;
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Authorize]
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
