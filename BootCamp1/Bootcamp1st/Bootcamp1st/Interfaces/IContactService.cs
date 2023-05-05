using Bootcamp1st.Models;

namespace Bootcamp1st.Interfaces
{
    public interface IContactService
    {
        Contact CreateContact(Contact contact);
        Contact SearchContactByEmail(string email);
        List<Contact> SearchContact();
        List<Contact> SearchContactByPosition(string phone);
        Contact UpdateContact(int id, Contact updateContact);
        Contact DeleteContact(int id);
    }
}
