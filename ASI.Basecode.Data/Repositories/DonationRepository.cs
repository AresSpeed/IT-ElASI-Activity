using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using Basecode.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ASI.Basecode.Data.Repositories
{
    public class DonationRepository : BaseRepository, IDonationRepository
    {
        List<Donation> _sampleDonationDB = new();
        private readonly AsiBasecodeDBContext _dbContext;

        public DonationRepository(AsiBasecodeDBContext dbContext, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Donation> ViewDonations()
        {
            return _dbContext.Donations.ToList();
        }

        public void AddDonation(Donation donation)
        {
            this.GetDbSet<Donation>().Add(donation); 
            UnitOfWork.SaveChanges(); 
        }

        public void EditDonation(Donation donation)
        {
            this.GetDbSet<Donation>().Update(donation);
            UnitOfWork.SaveChanges(); 
        }

        public void DeleteDonation(Donation donation)
        {
            _dbContext.Donations.Remove(donation); 
            UnitOfWork.SaveChanges(); 
        }
    }
}
