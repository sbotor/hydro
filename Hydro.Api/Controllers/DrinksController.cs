using Hydro.Api.Dto.Drink;
using Hydro.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hydro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private readonly DrinkService _drinkService;

        public DrinksController(DrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DrinkGetDto>> GetAllDrinks()
        {
            return Ok(_drinkService.GetAllDrinks());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<DrinkGetDto> GetDrinkById(long id)
        {
            return Ok(_drinkService.GetDrinkById(id));
        }

        [HttpPost]
        public IActionResult PostDrink([FromBody] DrinkPostDto drinkDto)
        {
            long id = _drinkService.AddDrink(drinkDto);
            return CreatedAtAction(nameof(GetDrinkById), new { id }, null);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult PutDrink(long id, [FromBody] DrinkPutDto drinkDto)
        {
            _drinkService.UpdateDrink(id, drinkDto);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteDrink(long id)
        {
            _drinkService.RemoveDrinkById(id);
            return Ok();
        }
    }
}
