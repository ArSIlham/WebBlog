using Application.Handler.CQRS.Queries;
using AutoMapper;
using Domain.Owner;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatePost.CreatePostRequest, AddPost>();

         




        }
    }
}
