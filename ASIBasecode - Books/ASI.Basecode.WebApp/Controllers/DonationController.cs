using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ASI.Basecode.WebApp.Controllers
{
    public class DonationController : Controller
    {
        private readonly IDonationService _donationService;

        public DonationController(IDonationService donationService)
        {
            this._donationService = donationService;
        }

        public IActionResult Index()
        {
            (bool result, IEnumerable<Donation> donations) = _donationService.GetDonations();
            if (result)
            {
                return View(donations);
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var donation = _donationService.GetDonations().Item2.ToList().FirstOrDefault(x => x.Id == id);
            return View(donation);
        }

        [HttpPost]
        public IActionResult Create(Donation donation)
        {
            try
            {
                _donationService.AddDonation(donation);
                return RedirectToAction("Index", "Donation");
            }
            catch (InvalidDataException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Donation donation)
        {
            _donationService.EditDonation(donation);
            TempData["SuccessMessage"] = "Donation Edited Successfully";
            return RedirectToAction("Index", "Donation");
        }

        public IActionResult Delete(int id)
        {
            var donation = _donationService.GetDonations().Item2.FirstOrDefault(x => x.Id == id);
            if (donation != null)
            {
                _donationService.DeleteDonation(donation);
            }
            return RedirectToAction("Index", "Donation");
        }
    }
}
