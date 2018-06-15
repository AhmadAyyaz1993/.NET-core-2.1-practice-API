using System;
using System.Collections.Generic;
using System.Linq;
using ContactsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApi.Managers
{
    public class ContactManager : IDataRepository<ContactItem>
    {
        private readonly DatabaseContext _context;

        public ContactManager(DatabaseContext databaseContext)
        {
            _context = databaseContext;
        }

        public ContactItem Create(ContactItem item)
        {
            _context.ContactItems.Add(item);
           _context.SaveChanges();

            ContactItem contactItem =  _context.ContactItems.Find(item.Id);

            return contactItem;
        }

        public ContactItem Delete(long id)
        {
            var contactItem = _context.ContactItems.Find(id);
            if (contactItem == null)
            {
                return null;
            }
            _context.ContactItems.Remove(contactItem);
            _context.SaveChanges();

            return contactItem;
        }

        public IEnumerable<ContactItem> GetAll()
        {
            return _context.ContactItems.ToList();
        }

        public ContactItem GetById(long id)
        {
            var item = _context.ContactItems.Find(id);
            if (item == null)
            {
                return null;
            }
            return item;
        }

        public ContactItem Update(long id, ContactItem item)
        {
            var contactItem = _context.ContactItems.Find(id);
            if (contactItem == null)
            {
                return null;
            }
            contactItem.Address = item.Address;
            contactItem.PhoneNumber = item.PhoneNumber;
            contactItem.Name = item.Name;

            _context.ContactItems.Update(contactItem);
            _context.SaveChanges();
            ContactItem item2 = _context.ContactItems.Find(contactItem.Id);
            return item2;
        }
    }
}
