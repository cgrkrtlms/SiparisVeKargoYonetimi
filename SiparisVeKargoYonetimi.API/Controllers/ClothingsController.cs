using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiparisVeKargoYonetimi.Core.Dtos;
using SiparisVeKargoYonetimi.Core.Models;
using SiparisVeKargoYonetimi.DATA.Services.IService;

namespace SiparisVeKargoYonetimi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothingsController : ControllerBase
    {
        private readonly IClothingService _clothingService;
        private readonly IMapper _mapper;
        public ClothingsController(IClothingService clothingService, IMapper mapper)
        {
            _clothingService = clothingService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clothing = await _clothingService.GetAll();
            var clothingDto = _mapper.Map<IEnumerable<ClothingDto>>(clothing);
            return Ok(clothingDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var food = await _clothingService.Get(id);
            var foodsDto = _mapper.Map<ClothingDto>(food);
            return Ok(foodsDto);
        }
        [HttpPost]
        public async Task<IActionResult> Save(ClothingDto clothingDto)
        {
            var clothing = _mapper.Map<Clothing>(clothingDto);
            var newClothing = await _clothingService.Add(clothing);
            return Created(String.Empty, null);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _clothingService.Delete(id);
            return NoContent();
        }
    }
}
