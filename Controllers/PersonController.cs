using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using netcsharp_api.Data;
using netcsharp_api.Models;

namespace netcsharp_api.Controllers;

[ApiController]
[Route("api/person")]
public class PersonController : ControllerBase
{
    private readonly AppDbContext _db;

    public PersonController(AppDbContext db)
    {
        _db = db;
    }

    // GET api/person
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var people = await _db.People.ToListAsync();
        return Ok(people);
    }

    // GET api/person/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var person = await _db.People.FindAsync(id);
        if (person == null) return NotFound();
        return Ok(person);
    }

    // POST api/person
    [HttpPost]
    public async Task<IActionResult> Create(Person person)
    {
        _db.People.Add(person);
        await _db.SaveChangesAsync();
        return Ok(person);
    }

    // PUT api/person/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Person updated)
    {
        var person = await _db.People.FindAsync(id);
        if (person == null) return NotFound();

        person.FirstName = updated.FirstName;
        person.LastName = updated.LastName;
        person.Email = updated.Email;
        person.Phone = updated.Phone;

        await _db.SaveChangesAsync();
        return Ok(person);
    }

    // DELETE api/person/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var person = await _db.People.FindAsync(id);
        if (person == null) return NotFound();

        _db.People.Remove(person);
        await _db.SaveChangesAsync();
        return Ok();
    }
}