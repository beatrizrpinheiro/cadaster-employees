using Bootcamp1st.Data;
using Bootcamp1st.Interfaces;
using Bootcamp1st.Models;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp1st.Services
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly EmployesContext _context;
        private readonly DbContextOptions<EmployesContext> _dbContextOptions;

        public ContactService(IConfiguration configuration, DbContextOptions<EmployesContext> dbContextOptions, EmployesContext context)
        {
            _httpClient = new HttpClient();
            _configuration = configuration;
            _dbContextOptions = dbContextOptions;
            _context = context;
        }

        //POST METHOD

        public Contact CreateContact(Contact newContact)
        {
            var contact = new Contact
            {
                Name = newContact.Name,
                Email = newContact.Email,
                Phone = newContact.Phone,
                Address = newContact.Address,
                City = newContact.City,
                BirthdayDate = newContact.BirthdayDate,
                PhoneNumber = newContact.PhoneNumber,
                Position = newContact.Position,
                Company = newContact.Company,
            };

            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return contact;
        }

        //READ
        public Contact? SearchContactByEmail(string email)
        {
            return _context.Contacts.FirstOrDefault(c => c.Email == email);
        }

        public List<Contact> SearchContact()
        {
            return _context.Contacts.ToList();
        }

        public List<Contact> SearchContactByPosition(string position)
        {
            return _context.Contacts.Where(c => c.Position == position).ToList();
        }

        //UPDATE

        public Contact? UpdateContact(int id, Contact updateContact)
        {
            Contact? contactToUpdate = _context.Contacts.FirstOrDefault(c => c.Id == id);
            if (contactToUpdate == null)
                return null;

            contactToUpdate.Name = updateContact.Name;
            contactToUpdate.Position = updateContact.Position;
            contactToUpdate.Email = updateContact.Email;
            contactToUpdate.Phone = updateContact.Phone;
            contactToUpdate.Address = updateContact.Address;
            contactToUpdate.City = updateContact.City;
            contactToUpdate.PhoneNumber = updateContact.PhoneNumber;
            contactToUpdate.BirthdayDate = updateContact.BirthdayDate;
            contactToUpdate.Company = updateContact.Company;

            _context.Contacts.Update(contactToUpdate);
            _context.SaveChanges();

            return contactToUpdate;
        }

        //DELETE

        public Contact? DeleteContact(int id)
        {
            Contact? contactToDelete = _context.Contacts.FirstOrDefault(c => c.Id == id);
            if (contactToDelete == null)
                return null;

            _context.Contacts.Remove(contactToDelete);
            _context.SaveChanges();

            return contactToDelete;
        }
    }
}
