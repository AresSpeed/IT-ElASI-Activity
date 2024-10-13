using ASI.Basecode.Data.Models;
using System.Collections.Generic;

namespace ASI.Basecode.Data.Interfaces
{
    public interface IContactsRepository
    {
        public IEnumerable<Contacts> ViewContacts();

        void AddContact(Contacts contact);
        void EditContact(Contacts contact);
        void DeleteContact(Contacts contact);

    }
}
