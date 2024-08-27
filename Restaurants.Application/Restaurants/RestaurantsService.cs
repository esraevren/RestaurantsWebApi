using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entitities;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants
{
    public class RestaurantsService(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantsService> logger, IMapper mapper) : IRestaurantsService
    {
        public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
        {
            logger.LogInformation("Getting all restaurants");
            var restaurants = await restaurantsRepository.GetAllAsync();
            var restaurantsDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
            return restaurantsDto!;
        }

        public async Task<RestaurantDto?> GetRestaurantById(int id)
        {
            logger.LogInformation("Getting restaurant by {id}");
            var restaurant = await restaurantsRepository.GetRestaurantById(id);
            var restaurantDto = mapper.Map<RestaurantDto>(restaurant);
            return restaurantDto;
        }
        public async Task<int> CreateRestaurant(CreateRestaurantDto restaurantDto)
        {
            logger.LogInformation("Creating restaurant by {id}");
            var restaurant = mapper.Map<Restaurant>(restaurantDto);
            var restaurantId = await restaurantsRepository.CreateRestaurant(restaurant);
            return restaurantId;
        }
    }
}
