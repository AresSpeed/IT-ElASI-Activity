using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace ASI.Basecode.Services.Services
{
    public class DonationService : IDonationService
    {
        private readonly IDonationRepository _donationRepository;

        public DonationService(IDonationRepository donationRepository)
        {
            this._donationRepository = donationRepository;
        }

        public (bool, IEnumerable<Donation>) GetDonations()
        {
            var donations = _donationRepository.ViewDonations();
            if (donations != null)
            {
                return (true, donations);
            }
            return (false, null);
        }

        public void AddDonation(Donation donation)
        {
            try
            {
                var newDonation = new Donation();
                newDonation.Donator = donation.Donator;
                newDonation.Description = donation.Description;
                newDonation.DateTimeCreated = donation.DateTimeCreated;
                _donationRepository.AddDonation(newDonation);
            }
            catch (Exception)
            {
                throw new InvalidDataException("Error Adding Donation.");
            }
        }

        public void EditDonation(Donation donation)
        {
            _donationRepository.EditDonation(donation);
        }

        public void DeleteDonation(Donation donation)
        {
            _donationRepository.DeleteDonation(donation);
        }
    }
}
