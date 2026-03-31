using AutoMapper;
using BookVaultApi.Data;
using BookVaultApi.DTOs;
using BookVaultApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookVaultApi.Services;

public class BookService(AppDbContext context, IMapper mapper) : IBookService
{
    public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
    {
        // "SELECT * FROM Books"
        var books = await context.Books.ToListAsync();

        return mapper.Map<IEnumerable<BookDto>>(books);
    }

    public async Task<BookDto?> GetBookByIdAsync(int id)
    {
        //SELECT * 
        //FROM Books 
        //WHERE Id = 1 
        //LIMIT 1;
        var book = await context.Books.FindAsync(id);
        return mapper.Map<BookDto>(book);
    }

    public async Task<BookDto> CreateBookAsync(CreateBookDto createBookDto)
    {
        var bookEntity = mapper.Map<Book>(createBookDto);

        context.Books.Add(bookEntity);
        await context.SaveChangesAsync();

        return mapper.Map<BookDto>(bookEntity);
    }

    public async Task<bool> UpdateBookAsync(int id, UpdateBookDto updateDto)
    {
        var book = await context.Books.FindAsync(id);
        if (book == null) return false;

        mapper.Map(updateDto, book);

        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        var book = await context.Books.FindAsync(id);
        if (book == null) return false;

        context.Books.Remove(book);
        await context.SaveChangesAsync();
        return true;
    }
}