namespace Domain.Entities
{
    public class Role
    {
        public int? ID { get; set; }
        public string? Name { get; set; }
        public List<User> LstUsers { get; set; }
    }
}
