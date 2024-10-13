using ASI.Basecode.Data.Models;
using System.Collections.Generic;

namespace ASI.Basecode.Data.Interfaces
{
    public interface IDonationRepository
    {
        IEnumerable<Donation> ViewDonations(); 

        void AddDonation(Donation donation); 
        void EditDonation(Donation donation); 
        void DeleteDonation(Donation donation); 
    }
}
