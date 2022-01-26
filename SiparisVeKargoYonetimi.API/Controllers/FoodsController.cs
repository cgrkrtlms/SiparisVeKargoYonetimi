using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiparisVeKargoYonetimi.Core.Dtos;
using SiparisVeKargoYonetimi.Core.Models;
using SiparisVeKargoYonetimi.DATA.Services.IService;

namespace SiparisVeKargoYonetimi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodService _foodService;
        private readonly IMapper _mapper;
        public FoodsController(IFoodService foodService, IMapper mapper)
        {
            _foodService = foodService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var foods = await _foodService.GetAll();
            var foodsDto = _mapper.Map<IEnumerable<FoodDto>>(foods);
            return Ok(foodsDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var food = await _foodService.Get(id);
            var foodsDto = _mapper.Map<FoodDto>(food);
            return Ok(foodsDto);
        }
        [HttpPost]
        public async Task<IActionResult> Save(FoodDto foodDto)
        {
            var food = _mapper.Map<Food>(foodDto);
            var newFood = await _foodService.Add(food);
            return Created(String.Empty, null);
        }
        [HttpDelete("{id}")]
        [Authorize("Admin")]
        public IActionResult Delete(int id)
        {
            var entity = _foodService.Delete(id);
            return NoContent();
        }
    }
}
