using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository,
        IMapper mapper, ILogger<DeleteRestaurantCommandHandler> logger) : IRequestHandler<DeleteRestaurantCommand>
    {
        public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Deleting restaurant by {request.Id}");
            var restaurant = await restaurantsRepository.GetRestaurantById(request.Id);
            if (restaurant is null)
            {
                throw new NotFoundException("DeleteRestaurantCommandHandler", $"{request.Id}");
            }

            await restaurantsRepository.DeleteRestaurant(restaurant);
        }
    }
}
