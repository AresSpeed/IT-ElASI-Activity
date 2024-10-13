using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ASI.Basecode.WebApp.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactsService _contactsService;
        //Constructor
        public ContactsController(IContactsService contactsService)
        {
            this._contactsService = contactsService;
        }
        public IActionResult Index()
        {
            (bool result, IEnumerable<Contacts> contacts) = _contactsService.GetContacts();
            if (result)
            {
                return View(contacts);
            }
            return View();

        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var contacts = _contactsService.GetContacts().Item2.ToList().FirstOrDefault(x => x.Id == id);
            return View(contacts);
        }

        [HttpPost]
        public IActionResult Create(Contacts contacts)
        {
            try
            {
                _contactsService.AddContact(contacts);
                return RedirectToAction("Index", "Contacts");
            }
            catch (InvalidDataException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Contacts contacts)
        {

            _contactsService.EditContact(contacts);
            TempData["SuccessMessage"] = "Contact Edited Successfully";
            return RedirectToAction("Index", "Contacts");
        }

        public IActionResult Delete(int id)
        {
            var contacts = _contactsService.GetContacts().Item2.FirstOrDefault(x => x.Id == id);
            if (contacts != null)
            {
                _contactsService.DeleteContact(contacts);
            }
            return RedirectToAction("Index", "Contacts");
        }
    }
}
