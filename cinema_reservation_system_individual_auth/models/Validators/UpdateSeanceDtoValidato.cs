using System;
using System.Linq;
using cinema_reservation_system_individual_auth.models.admin;
using cinema_reservation_system_individual_auth.models.worker;
using FluentValidation;

namespace cinema_reservation_system_individual_auth.models.Validators
{
    public class UpdateSeanceDtoValidator : AbstractValidator<UpdateSeanceDto>
    {
        public UpdateSeanceDtoValidator(CinemaDbContext dbContext)
        {
            RuleFor(x => x)
                .Custom((value, context) =>
                {
                    // TODO przy edycji seansu sprawdzać, czy dana sala w danym okienku czasowym (czas sprzątania + czas trwania + czas sprzątania) jest wolna
                });

        }
    }
}
