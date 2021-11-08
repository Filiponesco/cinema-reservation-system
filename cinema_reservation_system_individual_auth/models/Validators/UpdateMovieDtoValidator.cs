using System;
using System.Linq;
using cinema_reservation_system_individual_auth.models.admin;
using cinema_reservation_system_individual_auth.models.worker;
using FluentValidation;

namespace cinema_reservation_system_individual_auth.models.Validators
{
    public class UpdateMovieDtoValidator : AbstractValidator<UpdateMovieDto>
    {
        public UpdateMovieDtoValidator(CinemaDbContext dbContext)
        {
            RuleFor(x => x.Name)
               .NotEmpty()
               .MaximumLength(64).MinimumLength(1);

            RuleFor(x => x.DurationInMinutes).GreaterThan(1).LessThanOrEqualTo(5000);
               
        }
    }
}
