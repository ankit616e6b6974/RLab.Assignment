namespace RLab.DTO
{
    public class ExternalUser
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Avatar { get; set; }
    }

    public class ExternalUserResponse
    {
        public ExternalUser Data { get; set; } = new();
    }

    public class ExternalUserListResponse
    {
        public int Page { get; set; }
        public int Per_Page { get; set; }
        public int Total { get; set; }
        public int Total_Pages { get; set; }

        public List<ExternalUser> Data { get; set; } = new();
    }
}
