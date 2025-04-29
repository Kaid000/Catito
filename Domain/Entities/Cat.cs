using Domain.Enums;
using System.Reflection.Metadata;

namespace Domain.Entities
{
    public class Cat
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CatBreed Breed { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Color { get; set; }
        public float Weight { get; set; }
        public bool IsVaccinated { get; set; }
        public bool IsSterilized { get; set; }
        public Guid OwnerId { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
