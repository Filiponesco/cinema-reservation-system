using System;
using System.Linq;
using cinema_reservation_system_individual_auth.models.admin;
using cinema_reservation_system_individual_auth.models.worker;
using FluentValidation;

namespace cinema_reservation_system_individual_auth.models.Validators
{
    public class CreateMovieDtoValidator : AbstractValidator<CreateMovieDto>
    {
        public CreateMovieDtoValidator(CinemaDbContext dbContext)
        {
            RuleFor(x => x.Name)
               .NotEmpty()
               .MaximumLength(500).MinimumLength(1);


            RuleFor(x => x.Name)
                .Custom((value, context) =>
                {
                    var nameInUse = dbContext.Movies.Any(u => u.Name == value);
                    if (nameInUse)
                    {
                        context.AddFailure("Name", "That name is taken");
                    }
                });
            RuleFor(x => x.DurationInMinutes).GreaterThan(0).LessThanOrEqualTo(5000);
               
        }
    }
}
