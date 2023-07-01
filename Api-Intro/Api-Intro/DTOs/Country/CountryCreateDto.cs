using Api_Intro.Models;
using System.ComponentModel.DataAnnotations;

namespace Api_Intro.DTOs.Country
{
    public class CountryCreateDto
    {
        [Required]
        public string Name { get; set; }
        public string Capital { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
