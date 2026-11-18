using BookStore.DTOs;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController(IBookService bookService) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<BookDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var book = await bookService.GetByIdAsync(id, cancellationToken);

        return book is null ? NotFound() : Ok(book);
    }

    [HttpPost]
    public async Task<ActionResult<BookDto>> Add(CreateBookDto dto,CancellationToken cancellationToken)
    {
        var result = await bookService.AddAsync(dto, cancellationToken);

        if (!result.Created)
        {
            return Ok(result.Book);
        }

        return CreatedAtAction(nameof(GetById), new { id = result.Book.Id }, result.Book);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateBookDto dto, CancellationToken cancellationToken)
    {
        var updated = await bookService.UpdateAsync(id, dto, cancellationToken);

        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        try
        {
            var deleteSucceeded = await bookService.DeleteAsync(id, cancellationToken);
            return deleteSucceeded ? NoContent() : NotFound();
        }
        catch (DbUpdateException)
        {
            return Conflict("The book cannot be deleted because it is referenced by an order.");
        }
    }
}
