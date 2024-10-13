using System.Collections.Generic;
using ASI.Basecode.Data.Models;

namespace ASI.Basecode.Services.Interfaces
{
    public interface IContactsService
    {
        (bool, IEnumerable<Contacts>) GetContacts();

        void AddContact(Contacts contact);
        void EditContact(Contacts contact);
        void DeleteContact(Contacts contact);

    }
}
