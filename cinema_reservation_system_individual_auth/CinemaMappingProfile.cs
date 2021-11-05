using System;
using AutoMapper;
using cinema_reservation_system_individual_auth.models.admin;

namespace cinema_reservation_system_individual_auth
{
    public class CinemaMappingProfile : Profile
    {
        public CinemaMappingProfile()
        {
            CreateMap<User, WorkerDto>();
        }
    }
}
