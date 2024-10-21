using Microsoft.AspNetCore.Mvc;
using Contact01.Models;  // Assuming Contact model and ContactContext are in Models folder
using System.Linq;

public class HomeController : Controller
{
    // Injecting the ContactContext via constructor dependency injection
    private readonly ContactContext _context;

    public HomeController(ContactContext context)
    {
        _context = context;  // Initialize the context
    }

    // GET: Home/Index
    public IActionResult Index()
    {
        // Retrieve the list of contacts from the database
        var contacts = _context.Contacts.ToList();
        return View(contacts);
    }

    // GET: Home/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Home/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Contact contact)
    {
        if (ModelState.IsValid)
        {
            // Add the new contact to the database
            _context.Add(contact);
            _context.SaveChanges();  // Save changes to the database
            return RedirectToAction(nameof(Index));  // Redirect to the Index action after saving
        }
        return View(contact);
    }

    // GET: Home/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        // Find the contact in the database by ID
        var contact = _context.Contacts.Find(id);
        if (contact == null)
        {
            return NotFound();
        }
        return View(contact);
    }

    // POST: Home/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Contact contact)
    {
        if (id != contact.ContactId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(contact);  // Update the contact in the database
            _context.SaveChanges();    // Save the changes
            return RedirectToAction(nameof(Index));
        }
        return View(contact);
    }

    // DELETE: Home/Delete/5
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var contact = _context.Contacts.Find(id);  // Find the contact by ID
        if (contact == null)
        {
            return NotFound();
        }

        _context.Contacts.Remove(contact);  // Remove the contact from the database
        _context.SaveChanges();             // Save the changes
        return RedirectToAction(nameof(Index));
    }
}
