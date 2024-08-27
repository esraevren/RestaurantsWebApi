using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantsController(IRestaurantsService restaurantsService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAllRestaurants()
        {
            var restaurants = await restaurantsService.GetAllRestaurants();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantById([FromRoute] int id)
        {
            var restaurant = await restaurantsService.GetRestaurantById(id);
            if (restaurant is null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDto createRestaurantDto)
        {
            int id = await restaurantsService.CreateRestaurant(createRestaurantDto);
            return CreatedAtAction(nameof(GetRestaurantById), new { id }, id);
        }
    }
}
