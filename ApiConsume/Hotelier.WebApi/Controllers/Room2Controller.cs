using AutoMapper;
using Hotelier.BusinessLayer.Abstract;
using Hotelier.DTOLayer.DTOS.RoomDTO;
using Hotelier.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hotelier.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Room2Controller : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public Room2Controller(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _roomService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddRoom(AddRoomDTO addRoomDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Room>(addRoomDTO);
            var result = _roomService.TInsert(values);
            if (result == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(_mapper.Map<AddRoomDTO>(result));
            }
        }

    }
}
