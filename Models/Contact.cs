using System.ComponentModel.DataAnnotations;

namespace Contact01.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        public string FirstName { get; set; } // Mark as non-nullable

        public string LastName { get; set; } // Mark as non-nullable

        public string Phone { get; set; } // Mark as non-nullable

        public string Email { get; set; } // Mark as non-nullable

        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; } // Keep as nullable if needed
    }
}
