using System;
namespace ContactsApi.Models
{
    public class ContactItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
