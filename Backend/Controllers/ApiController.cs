using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Custom : ControllerBase
{
    private readonly string _deleteAllKey = "clear-all";

    [HttpGet("{id}")]
    public ActionResult<CustomDataTypeDTO> GetById(Guid id, CustomDatabaseContext db)
    {
        CustomDataType? entity = db.CustomData.FirstOrDefault(data => data.Id == id);
        return entity is not null ? Ok((CustomDataTypeDTO)entity) : NotFound();
    }

    [HttpGet]
    public ActionResult<List<CustomDataTypeDTO>> GetAll(CustomDatabaseContext db)
    {
        var entities = db.CustomData.ToList().Select(entity => (CustomDataTypeDTO)entity);
        return Ok(entities);
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

    [HttpDelete]
    public IActionResult DeleteAll(CustomDatabaseContext db)
    {
        db.RemoveRange(db.CustomData.ToList());
        db.SaveChanges();
        return Ok();
    }
}