using Microsoft.EntityFrameworkCore;

namespace Api_Intro.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
