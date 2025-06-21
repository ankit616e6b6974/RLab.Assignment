namespace RLab.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int? ExternalId { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Avatar { get; set; }
    }
}
