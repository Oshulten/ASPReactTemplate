using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Custom : ControllerBase
{
    [HttpGet("{id}")]
    public ActionResult<CustomDataTypeDTO> GetById(Guid id, CustomDatabaseContext db)
    {
        CustomDataType? entity = db.CustomData.FirstOrDefault(data => data.Id == id);
        return entity is not null ? Ok((CustomDataTypeDTO)entity) : NotFound();
    }

    [HttpPost]
    public IActionResult Post(CustomDataTypeDTO dto, CustomDatabaseContext db)
    {
        var entity = (CustomDataType)dto;
        db.Add<CustomDataType>(entity);
        db.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, null);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteById(Guid id, CustomDatabaseContext db)
    {
        CustomDataType? entity = db.CustomData.FirstOrDefault(data => data.Id == id);
        if (entity is null)
        {
            return NotFound();
        }
        db.Remove<CustomDataType>(entity);
        db.SaveChanges();
        return Ok();
    }
}