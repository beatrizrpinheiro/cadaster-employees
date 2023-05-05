using System.Globalization;

namespace Bootcamp1st.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get;set; } 
        public string Company { get; set; } 
    }
}
