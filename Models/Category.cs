using System.Collections.Generic;

namespace Contact01.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        // Required modifier ensures that this property is set when the object is created.
        public required string CategoryName { get; set; }

        // Navigation property
        public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    }

}
