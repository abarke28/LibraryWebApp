using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models.Dtos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Reader, ReaderDto>();
            CreateMap<ReaderDto, Reader>();

            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
        }
    }
}
