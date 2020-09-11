using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HotelRoomsController : Controller
    {
        private IHotelRoomRepository hotelRoomRepository;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HotelRoomsController(AppDbContext context, IWebHostEnvironment _webHostEnvironment)
        {
            _context = context;
            webHostEnvironment = _webHostEnvironment;
        }

        // GET: HotelRooms
            public async Task<IActionResult> Index()
            {
                return View(await _context.HotelRooms.ToListAsync());
            }

        // GET: HotelRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms.FindAsync(id);
            HotelRoomsCreateViewModel hotel = new HotelRoomsCreateViewModel();
            hotel.Acreage = hotelRoom.Acreage;
            hotel.Amount = hotelRoom.Amount;
            hotel.FullName = hotelRoom.FullName;
            hotel.urlImages = "/images/" + hotelRoom.Images;
            hotel.Id = hotelRoom.HotelRoomId;
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // GET: HotelRooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HotelRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("HotelRoomId,FullName,Images,Amount,Acreage")] HotelRoomsCreateViewModel model)
        {
            string nameImages = "";
            if (ModelState.IsValid)
            {
          
                string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                var fileName = $"{Guid.NewGuid()}_{model.Images.FileName}";
                nameImages = fileName;
                var filePath = Path.Combine(uploadFolder, fileName);
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    model.Images.CopyTo(fs);
                }

            }
            var hotel = new HotelRoom()
                {
                    FullName = model.FullName,
                    Amount = model.Amount,
                    Acreage = model.Acreage
                   
                };
            hotel.Images = nameImages;
                _context.HotelRooms.Add(hotel);
                await _context.SaveChangesAsync();
     


            
                return RedirectToAction("Index");
                
   
        }

        // GET: HotelRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms.FindAsync(id);
            HotelRoomsCreateViewModel hotel = new HotelRoomsCreateViewModel();
            hotel.Acreage = hotelRoom.Acreage;
            hotel.Amount = hotelRoom.Amount;
            hotel.FullName = hotelRoom.FullName;
            hotel.urlImages = "/images/"+hotelRoom.Images;
            hotel.Id = hotelRoom.HotelRoomId;

            if (hotelRoom == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        // POST: HotelRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id ,[Bind("Id,FullName,Images,Amount,Acreage,urlImages")] HotelRoomsCreateViewModel model)
        {
            string nameImages = "";
            if (ModelState.IsValid)
            {
                if (model.Images != null)
                {
                    string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    var fileName = $"{Guid.NewGuid()}_{model.Images.FileName}";
                    nameImages = fileName;
                    var filePath = Path.Combine(uploadFolder, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        model.Images.CopyTo(fs);
                    }
                }
               

            }
            var hotel = new HotelRoom()
            {
                HotelRoomId = model.Id,
                FullName = model.FullName,
                Amount = model.Amount,
                Acreage = model.Acreage

            };
            if (model.Images != null)
            {
                hotel.Images = nameImages;
            }
            else
            {
                for (int i = 8; i < model.urlImages.Length; i++)
                {
                    hotel.Images += model.urlImages[i];
                }
            }
           
            
            _context.HotelRooms.Update(hotel);
            await _context.SaveChangesAsync();




            return RedirectToAction("Index");
        }

        // GET: HotelRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms
                .FirstOrDefaultAsync(m => m.HotelRoomId == id);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // POST: HotelRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelRoom = await _context.HotelRooms.FindAsync(id);
            _context.HotelRooms.Remove(hotelRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelRoomExists(int id)
        {
            return _context.HotelRooms.Any(e => e.HotelRoomId == id);
        }

        public ViewResult Broom()
        {
            return View();
        }

        public ViewResult Event()
        {
            return View();
        }
        public ViewResult Wedding()
        {
            return View();
        }

        public ViewResult Romantics()
        {
            return View();
        }
    }
}
