using AutoMapper;
using Hotelier.DTOLayer.DTOS.RoomDTO;
using Hotelier.EntityLayer.Concrete;

namespace Hotelier.WebApi.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AddRoomDTO, Room>();
            CreateMap<Room, AddRoomDTO>();

            CreateMap<UpdateRoomDTO, Room>().ReverseMap();

        }
    }
}
