using Backend.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

/* 
To copy-paste this class for use with another database table
- Rename the class name manually
- Search and replace "DefaultTypeDto" with '{table-data-type}Dto'
- Search and replace "DefaultData" with '{new-table-name}'
*/

[ApiController]
[Route("api/[controller]")]
public class TemplateController : ControllerBase
{
    private readonly string _deleteAllKey = "clear-all";

    [HttpGet("{id}")]
    public ActionResult<DefaultDataTypeDto> GetById(Guid id, CustomDatabaseContext db)
    {
        DefaultDataType? entity = db.DefaultDataTable.FirstOrDefault(data => data.Id == id);
        return entity is not null ? Ok((DefaultDataTypeDto)entity) : NotFound();
    }

    [HttpGet]
    public ActionResult<List<DefaultDataTypeDto>> GetAll(CustomDatabaseContext db)
    {
        var entities = db.DefaultDataTable.ToList().Select(entity => (DefaultDataTypeDto)entity);
        return Ok(entities);
    }

    [HttpPost]
    public IActionResult Post(DefaultDataTypeDto dto, CustomDatabaseContext db)
    {
        var entity = (DefaultDataType)dto;
        db.Add<DefaultDataType>(entity);
        db.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, null);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteById(Guid id, CustomDatabaseContext db)
    {
        DefaultDataType? entity = db.DefaultDataTable.FirstOrDefault(data => data.Id == id);
        if (entity is null)
        {
            return NotFound();
        }
        db.Remove<DefaultDataType>(entity);
        db.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteAll(string deleteAllKey, CustomDatabaseContext db)
    {
        if (deleteAllKey != _deleteAllKey)
        {
            return Unauthorized();
        }

        db.RemoveRange(db.DefaultDataTable.ToList());
        db.SaveChanges();
        return Ok();
    }
}