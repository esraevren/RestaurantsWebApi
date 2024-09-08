using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Domain.Entitities;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository, IMapper mapper, 
        ILogger<DeleteRestaurantCommandHandler> logger) : IRequestHandler<UpdateRestaurantCommand>
    {
        public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updating restaurant by {id}");
            var restaurant = await restaurantsRepository.GetRestaurantById(request.Id);
            if (restaurant is null)
            {
                throw new Exception($"Restaurant with id {request.Id} doesn't exist");
            }

            restaurant.Name = request.Name;
            restaurant.Description = request.Description;
            restaurant.HasDelivery = request.HasDelivery;
            mapper.Map(request, restaurant);

            await restaurantsRepository.SaveChanges();
        }
    }
}
