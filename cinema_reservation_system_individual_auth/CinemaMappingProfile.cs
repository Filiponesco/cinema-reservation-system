using System;
using AutoMapper;
using cinema_reservation_system_individual_auth.entities;
using cinema_reservation_system_individual_auth.Helpers;
using cinema_reservation_system_individual_auth.models;
using cinema_reservation_system_individual_auth.models.admin;
using cinema_reservation_system_individual_auth.models.worker;

namespace cinema_reservation_system_individual_auth
{
    public class CinemaMappingProfile : Profile
    {
        public CinemaMappingProfile()
        {


            CreateMap<User, LoginDto>()
                .ForMember(m => m.Password, c => c.MapFrom(s => CaesarCipher.Decipher(s.Password, Consts.CeasarCipherKey)));

            CreateMap<RegisterAdminDto, User>()
                .ForMember(m => m.RoleId, c => c.MapFrom(s => 2))
                .ForMember(m => m.Password, c => c.MapFrom(s => CaesarCipher.Encipher(RandomStringGenerator.RandomString(Consts.RandomPasswordLength), Consts.CeasarCipherKey)));



            CreateMap<User, WorkerDto>()
                .ForMember(m => m.Password, c => c.MapFrom(s => CaesarCipher.Decipher(s.Password, Consts.CeasarCipherKey)));

            CreateMap<CreateWorkerDto, User>()
                .ForMember(m => m.RoleId, c => c.MapFrom(s => 2))
                .ForMember(m => m.Password, c => c.MapFrom(s => CaesarCipher.Encipher(RandomStringGenerator.RandomString(Consts.RandomPasswordLength), Consts.CeasarCipherKey)));

            CreateMap<Room, RoomDto>();
            CreateMap<CreateRoomDto, Room>();
            CreateMap<Movie, MovieDto>();
            CreateMap<CreateMovieDto, Movie>();
            CreateMap<Seance, SeanceDto>();
            CreateMap<CreateSeanceDto, Seance>();
            CreateMap<Reservation, ReserveDto>();
            CreateMap<CreateReserveDto, Reservation>();

            CreateMap<User, UserDto>();
            CreateMap<Role, RoleDto>();

        }
    }
}
