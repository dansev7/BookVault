using AutoMapper;
using BookVaultApi.Models;
using BookVaultApi.DTOs;

namespace BookVaultApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Outgoing: Map from Entity to DTO
        CreateMap<Book, BookDto>();

        // Incoming: Map from DTO to Entity
        CreateMap<CreateBookDto, Book>();

        // Update: Map DTO to existing Entity, ignoring null properties
        CreateMap<UpdateBookDto, Book>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}
