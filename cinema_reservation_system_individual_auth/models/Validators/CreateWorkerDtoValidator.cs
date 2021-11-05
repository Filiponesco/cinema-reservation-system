using System;
using System.Linq;
using cinema_reservation_system_individual_auth.models.admin;
using FluentValidation;

namespace cinema_reservation_system_individual_auth.models.Validators
{
    public class CreateWorkerDtoValidator : AbstractValidator<CreateWorkerDto>
    {
        public CreateWorkerDtoValidator(CinemaDbContext dbContext)
        {
            RuleFor(x => x.Email)
               .NotEmpty()
               .EmailAddress();


            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Users.Any(u => u.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });
        }
    }
}
