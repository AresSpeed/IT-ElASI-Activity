using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using Basecode.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ASI.Basecode.Data.Repositories
{
    public class ContactsRepository : BaseRepository, IContactsRepository
    {
        List<Contacts> _sampleContactsDB = new();

        private readonly AsiBasecodeDBContext _dbContext;
        public ContactsRepository(AsiBasecodeDBContext dbContext, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Contacts> ViewContacts()
        {
            return _dbContext.Contacts.ToList();
        }

        public void AddContact(Contacts contact)
        {
            this.GetDbSet<Contacts>().Add(contact);
            UnitOfWork.SaveChanges();
        }

        public void EditContact(Contacts contact)
        {
            this.GetDbSet<Contacts>().Update(contact);
            UnitOfWork.SaveChanges();
        }

        public void DeleteContact(Contacts contact)
        {
            _dbContext.Contacts.Remove(contact);
            UnitOfWork.SaveChanges();
        }
    }
}
