using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Data.Entities
{
    public class Cars
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Phone { get; set; }
        public double Engine { get; set; }
        public string State_number { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public int Year { get; set; }
        public int CategoryId { get; set; }
        public bool IsUsed { get; set; }
        public string? Mail { get; set; }
        public string? ImageUrl { get; set; }
        public string City { get; set; }
        public string? Description { get; set; }
        public Category? Category { get; set; }
        //public ICollection<Favorite>? Favorites { get; set; }
    }
}
