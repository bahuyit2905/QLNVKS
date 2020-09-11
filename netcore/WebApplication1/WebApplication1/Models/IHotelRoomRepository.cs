using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    interface IHotelRoomRepository
    {
        IEnumerable<HotelRoom> Gets();
        HotelRoom Get(int id);
        HotelRoom Create(HotelRoom hotelRoom);
        HotelRoom Edit(HotelRoom hotelRoom);
        bool Delete(int id);
    }
}
