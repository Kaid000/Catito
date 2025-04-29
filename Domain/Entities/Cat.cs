using Domain.Enums;

namespace Domain.Entities
{
    public class Cat
    {
        public Guid Id { get; set; }

        required public string Name { get; set; }

        public CatBreed Breed { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        required public string Color { get; set; }

        public float Weight { get; set; }

        public bool IsVaccinated { get; set; }

        public bool IsSterilized { get; set; }

        public Guid OwnerId { get; set; }

        required public User User { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
