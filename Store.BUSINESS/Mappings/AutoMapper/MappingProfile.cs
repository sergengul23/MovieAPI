using AutoMapper;
using Store.BUSINESS.DTOs.RequestDTOs;
using Store.MODELS.Entities;

namespace Store.BUSINESS.Mappings.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, CreateMovieDTO>().ReverseMap();
            CreateMap<Movie, UpdateMovieDTO>().ReverseMap();

            CreateMap<Genre, CreateGenreDTO>().ReverseMap();
            CreateMap<Genre, UpdateGenreDTO>().ReverseMap();

            CreateMap<Director, CreateDirectorDTO>().ReverseMap();
            CreateMap<Director, UpdateDirectorDTO>().ReverseMap();

            CreateMap<Actor, CreateActorDTO>().ReverseMap();
            CreateMap<Actor, UpdateActorDTO>().ReverseMap();
        }
    }
}
