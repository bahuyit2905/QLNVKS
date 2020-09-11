using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class HotelRoomRepository : IHotelRoomRepository
    {
        private List<HotelRoom> hotelRooms;

        public HotelRoom Create(HotelRoom hotelRoom)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public HotelRoom Edit(HotelRoom hotelRoom)
        {
            throw new NotImplementedException();
        }

        public HotelRoom Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HotelRoom> Gets()
        {
            return hotelRooms;
        }
    }
}
