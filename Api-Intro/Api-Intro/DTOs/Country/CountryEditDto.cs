using Api_Intro.Models;

namespace Api_Intro.DTOs.Country
{
    public class CountryEditDto
    {
        public string Name { get; set; }
        public string Capital { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
