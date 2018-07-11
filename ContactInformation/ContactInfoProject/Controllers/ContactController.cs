using ContactInfoProject.Models;
using System.Linq;
using System.Web.Mvc;

/***
 * Created Date : 10-Jul-2018
 * Created by   : Nitin Kurle
 * Information  : Controller class having all the API.
 * **/

namespace ContactInfoProject.Controllers
{
    public class ContactController : Controller
    {
        //Declare instance of entities
        private ContactInfoEntities db = new ContactInfoEntities();
        IContactRepository contactRepository;
        //Default constructor
        public ContactController() : this(new ContactRepository()) { }

        //Contact constuctor with repo paramters
        public ContactController(IContactRepository repository)
        {
            contactRepository = repository;
        }

        // GET: Contact
        public ViewResult Index()
        {
            ViewData["ControllerName"] = this.ToString();
            var contact = from c in contactRepository.GetAllContact()
                            select c;

            return View(contact.ToList());
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            var contact = contactRepository.GetContactByID(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,PhoneNumber,Status")] tbl_contact tbl_contact)
        {
            if (ModelState.IsValid)
            {
                contactRepository.InsertContact(tbl_contact);
                contactRepository.Save();
                return RedirectToAction("Index");
            }

            return View(tbl_contact);
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            var contact = contactRepository.GetContactByID(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,PhoneNumber,Status")] tbl_contact tbl_contact)
        {
            if (ModelState.IsValid)
            {
                contactRepository.UpdateContact(tbl_contact);
                contactRepository.Save();
                return RedirectToAction("Index");
            }
            return View(tbl_contact);
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            var contact = contactRepository.GetContactByID(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var contact = contactRepository.GetContactByID(id);
            contactRepository.DeleteContact(id);
            contactRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
