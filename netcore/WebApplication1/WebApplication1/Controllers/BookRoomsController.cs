using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BookRoomsController : Controller
    {
        private readonly AppDbContext _context;

        public BookRoomsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BookRooms
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookRooms.ToListAsync());
        }

        // GET: BookRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookRoom = await _context.BookRooms
                .FirstOrDefaultAsync(m => m.BookRoomId == id);
            if (bookRoom == null)
            {
                return NotFound();
            }

            return View(bookRoom);
        }


        // GET: BookRooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookRoomId,Name,FromDate,NumberPeople,TelePhone,Address")] BookRoom bookRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookRoom);
        }

        // GET: BookRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookRoom = await _context.BookRooms.FindAsync(id);
            if (bookRoom == null)
            {
                return NotFound();
            }
            return View(bookRoom);
        }

        // POST: BookRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookRoomId,Name,FromDate,NumberPeople,TelePhone,Address")] BookRoom bookRoom)
        {
            if (id != bookRoom.BookRoomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookRoomExists(bookRoom.BookRoomId))
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
            return View(bookRoom);
        }

        // GET: BookRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookRoom = await _context.BookRooms
                .FirstOrDefaultAsync(m => m.BookRoomId == id);
            if (bookRoom == null)
            {
                return NotFound();
            }

            return View(bookRoom);
        }

        // POST: BookRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookRoom = await _context.BookRooms.FindAsync(id);
            _context.BookRooms.Remove(bookRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookRoomExists(int id)
        {
            return _context.BookRooms.Any(e => e.BookRoomId == id);
        }
    }
}
