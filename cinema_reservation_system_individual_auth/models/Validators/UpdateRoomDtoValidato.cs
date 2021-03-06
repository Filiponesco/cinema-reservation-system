using System;
using System.Linq;
using cinema_reservation_system_individual_auth.models.admin;
using cinema_reservation_system_individual_auth.models.worker;
using FluentValidation;

namespace cinema_reservation_system_individual_auth.models.Validators
{
    public class UpdateRoomDtoValidator : AbstractValidator<UpdateRoomDto>
    {
        public UpdateRoomDtoValidator(CinemaDbContext dbContext)
        {
            RuleFor(x => x.Name)
               .NotEmpty()
               .MaximumLength(64).MinimumLength(1);
            RuleFor(x => x.SeatsCount).GreaterThan(0).LessThanOrEqualTo(10000);
               
        }
    }
}
