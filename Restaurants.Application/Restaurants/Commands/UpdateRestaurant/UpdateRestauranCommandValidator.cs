﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestauranCommandValidator: AbstractValidator<UpdateRestaurantCommand>
    {
        public UpdateRestauranCommandValidator()
        {
            RuleFor(c => c.Name)
                .Length(3, 10);
        }
    }
}
