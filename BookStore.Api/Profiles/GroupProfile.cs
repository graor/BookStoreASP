using AutoMapper;
using BookStore.Application.DataTransfer;
using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.Profiles
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<Group, GroupDto>();
            CreateMap<GroupDto, Group>();
        }
    }
}
