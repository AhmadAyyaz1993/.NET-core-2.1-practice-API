using System;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            :base(options)
        {
        }

        public DbSet<ContactItem> ContactItems { get; set; }
    }
}
