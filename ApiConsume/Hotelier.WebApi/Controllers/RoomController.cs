using Hotelier.BusinessLayer.Abstract;
using Hotelier.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomservice;

        public RoomController(IRoomService roomservice)
        {
            _roomservice = roomservice;
        }

        [HttpGet]
        public IActionResult RoomList()
        {
            var values = _roomservice.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddRoom(Room Room)
        {
            _roomservice.TInsert(Room);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteRoom(int id)
        {
            var values = _roomservice.TGetByID(id);
            _roomservice.TDelete(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateRoom(Room Room)
        {
            _roomservice.TUpdate(Room);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetRoom(int id)
        {
            var values = _roomservice.TGetByID(id);
            return Ok(values);
        }
    }
}
