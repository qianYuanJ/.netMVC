using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using netcoremvc;

namespace netcoremvc.Controllers
{
    public class RegistrationInfoesController : Controller
    {
        private readonly registerdbContext _context;

        public RegistrationInfoesController(registerdbContext context)
        {
            _context = context;
        }

        // GET: RegistrationInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegistrationInfos.ToListAsync());
        }

        // GET: RegistrationInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrationInfo = await _context.RegistrationInfos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registrationInfo == null)
            {
                return NotFound();
            }

            return View(registrationInfo);
        }

        // GET: RegistrationInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegistrationInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Sex,Age,Birthday,Mobile,Temperature,CreateTime")] student registrationInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registrationInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registrationInfo);
        }

        // GET: RegistrationInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrationInfo = await _context.RegistrationInfos.FindAsync(id);
            if (registrationInfo == null)
            {
                return NotFound();
            }
            return View(registrationInfo);
        }

        // POST: RegistrationInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Sex,Age,Birthday,Mobile,Temperature,CreateTime")] student registrationInfo)
        {
            if (id != registrationInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registrationInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrationInfoExists(registrationInfo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(registrationInfo);
        }

        // GET: RegistrationInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrationInfo = await _context.RegistrationInfos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registrationInfo == null)
            {
                return NotFound();
            }

            return View(registrationInfo);
        }

        // POST: RegistrationInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registrationInfo = await _context.RegistrationInfos.FindAsync(id);
            _context.RegistrationInfos.Remove(registrationInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrationInfoExists(int id)
        {
            return _context.RegistrationInfos.Any(e => e.Id == id);
        }
    }
}
