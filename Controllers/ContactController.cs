using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Contact01.Models;  // Use the correct namespace for your models
using System.Threading.Tasks;
using System.Linq; // This is required for LINQ extension methods


namespace Contact01.Controllers
{ 
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Contact
        public async Task<IActionResult> Index()
        {
            var contacts = await _context.Contacts.Include(c => c.Category).ToListAsync();
            return View(contacts);
        }

        // GET: Contact/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var contact = await _context.Contacts
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.ContactId == id);

            if (contact == null) return NotFound();

            return View(contact);
        }

        // GET: Contact/Create
        public IActionResult Create()
        {
            ViewData["Categories"] = _context.Categories;
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Phone,Email,CategoryId")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // GET: Contact/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null) return NotFound();

            ViewData["Categories"] = _context.Categories;
            return View(contact);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactId,FirstName,LastName,Phone,Email,CategoryId")] Contact contact)
        {
            if (id != contact.ContactId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.ContactId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // GET: Contact/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var contact = await _context.Contacts
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (contact == null) return NotFound();

            return View(contact);
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Find the contact by ID
            var contact = await _context.Contacts.FindAsync(id);

            // Check if the contact exists before attempting to remove it
            if (contact == null)
            {
                return NotFound(); // Return NotFound if the contact does not exist
            }

            // Remove the contact
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.ContactId == id);
        }
    }
}