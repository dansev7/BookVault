using BookVaultApi.DTOs;

namespace BookVaultApi.Services;

public interface IBookService
{
    Task<IEnumerable<BookDto>> GetAllBooksAsync();

    Task<BookDto?> GetBookByIdAsync(int id);
    
    Task<BookDto> CreateBookAsync(CreateBookDto createBookDto);

    Task<bool> UpdateBookAsync(int id, UpdateBookDto updateDto);
    
    Task<bool> DeleteBookAsync(int id);
}