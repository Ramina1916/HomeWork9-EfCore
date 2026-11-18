using BookStore.DTOs;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController(IBookService bookService) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<BookDto>> GetById(
        int id,
        CancellationToken cancellationToken)
    {
        var book = await bookService.GetByIdAsync(id, cancellationToken);

        return book is null ? NotFound() : Ok(book);
    }
}
