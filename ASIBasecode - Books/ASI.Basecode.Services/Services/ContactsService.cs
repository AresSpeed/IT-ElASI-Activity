using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace ASI.Basecode.Services.Services
{
    public class ContactsService : IContactsService
    {
        private readonly IContactsRepository _contactsRepository;

        //Constructor
        public ContactsService(IContactsRepository contactsRepository)
        {
            this._contactsRepository = contactsRepository;
        }

        public (bool, IEnumerable<Contacts>) GetContacts()
        {
            var contacts = _contactsRepository.ViewContacts();
            if (contacts != null)
            {
                return (true, contacts);
            }
            return (false, null);
        }

        public void AddContact(Contacts contact)
        {
            try
            {
                var newContact = new Contacts();
                newContact.Name = contact.Name;
                newContact.Number = contact.Number;
                newContact.Address = contact.Address;
                _contactsRepository.AddContact(newContact);
            }
            catch (Exception)
            {
                throw new InvalidDataException("Error Adding Contact.");
            }

        }

        public void EditContact(Contacts contact)
        {
            _contactsRepository.EditContact(contact);
        }

        public void DeleteContact(Contacts contact)
        {
            _contactsRepository.DeleteContact(contact);
        }
    }
}
