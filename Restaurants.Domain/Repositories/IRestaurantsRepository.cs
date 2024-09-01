using Restaurants.Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Domain.Repositories
{
    public interface IRestaurantsRepository
    {
        Task<IEnumerable<Restaurant>> GetAllAsync();
        Task<Restaurant?> GetRestaurantById(int id);
        Task<int> CreateRestaurant(Restaurant restaurantEntity);
        Task DeleteRestaurant(Restaurant restaurantEntity);
        Task SaveChanges();
    }
}
