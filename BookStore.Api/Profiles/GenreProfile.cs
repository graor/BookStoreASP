using AutoMapper;
using BookStore.Application.DataTransfer;
using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreDto>();
            CreateMap<GenreDto, Genre>();
        }
    }
}
