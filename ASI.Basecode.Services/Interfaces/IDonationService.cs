using ASI.Basecode.Data.Models;
using System.Collections.Generic;

namespace ASI.Basecode.Services.Interfaces
{
    public interface IDonationService
    {
        (bool, IEnumerable<Donation>) GetDonations();

        void AddDonation(Donation donation);
        void EditDonation(Donation donation);
        void DeleteDonation(Donation donation);
    }
}
