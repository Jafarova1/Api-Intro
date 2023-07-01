using Api_Intro.Data;
using Api_Intro.DTOs.Country;
using Api_Intro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Api_Intro.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CountryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Country country = await _context.Countries.FirstOrDefaultAsync(m => m.Id == id);
            if (country == null) { return NotFound(); }
            return Ok(country);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Country> countries = await _context.Countries.ToListAsync();
            return Ok(countries);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CountryCreateDto request)
        {
            if (!ModelState.IsValid)
            {
                return (BadRequest(ModelState));
            };

            Country country = new()
            {
                Name = request.Name,
                Capital = request.Capital,
                Cities = request.Cities,
            };

            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery][Required] int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(m => m.Id == id);
            if (country == null) { return NotFound(); }
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpPut]
        [Route("api/resource/{id}")]

        public async Task<IActionResult> Update(int id, [FromBody] CountryEditDto request)
        {
            var countries = await _context.Countries.FirstOrDefaultAsync(m => m.Id == id);
            if (countries == null) return NotFound();
            countries.Name = request.Name;
            countries.Capital = request.Capital;
            countries.Cities = request.Cities;
            await _context.SaveChangesAsync();
            return Ok();

        }

        //[HttpGet]
        //[Route("api/resource/search")]
        //public async Task<IActionResult> Search([FromBody] int id)
        //{
        //    var result = await _context.Countries.Where(m => m.Id == id).ToListAsync();
        //    return Ok(result);


        //}

        [HttpGet]
        [Route("api/resource/search")]
        public async Task<IActionResult> Search(string query)
        {
            var result = await _context.Countries.Where(m => m.Name.Contains(query) || m.Capital.Contains(query)).ToListAsync();
            return Ok(result);
        }
    }
}
