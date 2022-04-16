using Hydro.Api.Dto.Beverage;
using Hydro.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hydro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeveragesController : ControllerBase
    {
        private readonly BeverageService _beverageService;

        public BeveragesController(BeverageService beverageService)
        {
            _beverageService = beverageService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BeverageGetDto>> GetAllBeverages()
        {
            return Ok(_beverageService.GetAllBeverages());
        }
        
        [HttpGet]
        [Route("{id}")]
        public ActionResult<BeverageGetDto> GetBeverageById(long id)
        {
            return Ok(_beverageService.GetBeverageById(id));
        }

        [HttpPost]
        public IActionResult PostBeverage([FromBody] BeveragePostDto beverageDto)
        {
            long id = _beverageService.AddBeverage(beverageDto);

            return CreatedAtAction(nameof(GetBeverageById), new { id }, null);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult PutBeverage(long id, [FromBody] BeveragePutDto beverageDto)
        {
            _beverageService.UpdateBeverage(id, beverageDto);

            return Ok();
        }

        // TODO: Parameter to remove all related Drinks.
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBeverage(long id)
        {
            _beverageService.RemoveBeverageById(id);

            return Ok();
        }
    }
}
