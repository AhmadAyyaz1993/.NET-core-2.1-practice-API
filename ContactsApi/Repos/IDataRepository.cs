using System;
using System.Collections.Generic;
using ContactsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApi
{
    public interface IDataRepository<TEntity> where TEntity : class  
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(long id);
        TEntity Create(TEntity item);
        TEntity Update(long id, TEntity item);
        TEntity Delete(long id);
    }
}
