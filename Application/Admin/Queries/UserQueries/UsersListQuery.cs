namespace Application.Admin.Queries.UserQueries
{
    public class ULQ_UsersListQuery
    {
        public int? ID { get; set; }
        public string? Username { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? BackupEmail { get; set; }
        public string? Phone { get; set; }
        public string? BackupPhone { get; set; }
        public bool? IsActive { get; set; }
        public ULQ_Role Role { get; set; }
    }

    public class ULQ_Role
    {
        public int? ID { get; set; }
        public string? Name { get; set; }
    }
}
