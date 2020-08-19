using AutoMapper;
using BookRtv.Dtos;
using BookRtv.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRtv.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, BookToReturnDto>()
                .ForMember(d => d.Author, o => o.MapFrom(s => s.Author.AuthorName))
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.CategoryName));
        }
    }
}
