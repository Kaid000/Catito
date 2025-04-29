namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        required public string Email { get; set; }

        required public string PasswordHash { get; set; }

        public ICollection<Cat>? Cats { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
