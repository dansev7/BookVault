using AutoMapper;
using BookVaultApi.Models;
using BookVaultApi.DTOs;

namespace BookVaultApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookDto>();

        CreateMap<CreateBookDto, Book>();

        CreateMap<UpdateBookDto, Book>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}
