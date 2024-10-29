using AutoMapper;
using Ecommerce.Core.DTO;
using Ecommerce.Core.Models;

namespace Ecommerce.API.mapping_profile
{
    public class Mapping_Profile : Profile
    {
        public Mapping_Profile()
        {
            CreateMap<Movie, MovieDTO>().ForMember(To => To.genre_Name, From => From.MapFrom(x => x.Genres != null ? x.Genres.Name : null));
            CreateMap<Create_UpdateMovieDTO, Movie>()
               .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.GenreId));
            CreateMap<Movie, MovieDTO>()
            .ForMember(dest => dest.genre_Name, opt => opt.MapFrom(src => src.Genres.Name));
            CreateMap<Genre, GenreDTO>().ReverseMap();

            // Mapping from Create_UpdateGenreDTO to Genre
            CreateMap<Create_UpdateGenreDTO, Genre>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignore Id for creation
            CreateMap<Genre, Create_UpdateGenreDTO>();
            // Map from MovieDTO to Movie
            CreateMap<MovieDTO, Movie>();
            CreateMap<Order, OrderDTO>().ForMember(dest => dest.LocalUserId, opt => opt.MapFrom(src => src.LocalUserId));
            CreateMap<LocalUser, LocalUserDTO>().ReverseMap();
        }
    }
}