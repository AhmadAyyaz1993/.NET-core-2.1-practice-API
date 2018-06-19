using System;
using System.Collections.Generic;
using System.Linq;
using ContactsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Managers
{
    public class ContactManager<TEntity> : IDataRepository<TEntity> where TEntity : class
    {
        private readonly DatabaseContext _context;
        private DbSet<TEntity> entities;
        public ContactManager(DatabaseContext databaseContext)
        {
            _context = databaseContext;
            entities = _context.Set<TEntity>();
        }

        public TEntity Create(TEntity item)
        {
            entities.Add(item);
           _context.SaveChanges();

           // TEntity entity =  entities.Find(item.Id);

            return item;
        }

        public TEntity Delete(long id)
        {
            var item = entities.Find(id);
            //if (contactItem == null)
            //{
            //    return null;
            //}

            entities.Remove(item);
            _context.SaveChanges();

            return item;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return entities.ToList();
        }

        public TEntity GetById(long id)
        {
            var item = entities.Find(id);
            if (item == null)
            {
                return null;
            }
            return item;
        }

        public TEntity Update(TEntity item)
        {
            
            entities.Update(item);
            _context.SaveChanges();
            //ContactItem item2 = _context.ContactItems.Find(contactItem.Id);
            return item;
        }
    }
}
