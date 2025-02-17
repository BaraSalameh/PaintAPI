namespace Domain.Entities
{
    public class User
    {
        public int? ID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? BackupEmail { get; set; }
        public string? Phone { get; set; }
        public string? BackupPhone { get; set; }
        public bool? IsActive { get; set; }
        public int? RoleID { get; set; }
        public Role Role { get; set; }
        public List<Paint> LstPaints { get; set; }
        public List<System_Language> LstSystemLanguages { get; set; }
    }
}
