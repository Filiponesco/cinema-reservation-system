using System;
using System.Linq;
using cinema_reservation_system_individual_auth.models.admin;
using cinema_reservation_system_individual_auth.models.worker;
using FluentValidation;

namespace cinema_reservation_system_individual_auth.models.Validators
{
    public class CreateReserveDtoValidator : AbstractValidator<CreateReserveDto>
    {
        public CreateReserveDtoValidator(CinemaDbContext dbContext)
        {
            RuleFor(x => x.Count).GreaterThan(1).LessThanOrEqualTo(10000);


            // TODO sprawdzić czy seans z określonym id istnieje
            // TODO sprawdzić czy są wolne miejsca
               
        }
    }
}
