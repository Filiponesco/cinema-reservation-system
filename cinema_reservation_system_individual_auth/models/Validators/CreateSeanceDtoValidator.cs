using System;
using System.Linq;
using cinema_reservation_system_individual_auth.models.admin;
using cinema_reservation_system_individual_auth.models.worker;
using FluentValidation;

namespace cinema_reservation_system_individual_auth.models.Validators
{
    public class CreateSeanceDtoValidator : AbstractValidator<CreateSeanceDto>
    {
        public CreateSeanceDtoValidator(CinemaDbContext dbContext)
        {

            RuleFor(x => x)
                .Custom((value, context) =>
                {
                // TODO przy tworzeniu seansu sprawdzać, czy dana sala w danym okienku czasowym (czas sprzątania + czas trwania + czas sprzątania) jest wolna
                });
               
        }
    }
}
