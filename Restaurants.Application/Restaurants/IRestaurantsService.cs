﻿using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entitities;

namespace Restaurants.Application.Restaurants
{
    public interface IRestaurantsService
    {
        Task<IEnumerable<RestaurantDto?>> GetAllRestaurants();
        Task<RestaurantDto?> GetRestaurantById(int id);
    }
}