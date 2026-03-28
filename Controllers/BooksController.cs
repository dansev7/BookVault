using Microsoft.AspNetCore.Mvc;
using BookVaultApi.DTOs;
using BookVaultApi.Services;

namespace BookVaultApi.Controllers;


[ApiController] 
[Route("api/[controller]")] 
public class BooksController(IBookService bookService) : ControllerBase 
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
    {
        var books = await bookService.GetAllBooksAsync();
        return Ok(books); 
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> GetBook(int id) 
    {
        var book = await bookService.GetBookByIdAsync(id);

        if (book == null)
        {
            return NotFound(); 
        }

        return Ok(book); 
    }

    [HttpPost]
    public async Task<ActionResult<BookDto>> CreateBook(CreateBookDto createBookDto)
    {

        var newBook = await bookService.CreateBookAsync(createBookDto);

        return CreatedAtAction(nameof(GetBook), new { id = newBook.Id }, newBook);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookDto updateDto)
    {
        var result = await bookService.UpdateBookAsync(id, updateDto);
        
        if (!result) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var result = await bookService.DeleteBookAsync(id);
        
        if (!result) return NotFound();

        return NoContent(); 
    }
}