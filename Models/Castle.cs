using System.ComponentModel.DataAnnotations;

namespace castle.Models
{
    public class Castle
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Location { get; set; }

        public int YearBuilt { get; set; }
    }
}