using AutoMapper;
using SiparisVeKargoYonetimi.Core.Dtos;
using SiparisVeKargoYonetimi.Core.Models;

namespace SiparisVeKargoYonetimi.API.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Food, FoodDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Clothing, ClothingDto>().ReverseMap();
        }
    }
}
