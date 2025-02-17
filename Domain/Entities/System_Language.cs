namespace Domain.Entities
{
    public class System_Language
    {
        public int? ID { get; set; }
        public string? Key { get; set; }
        public string? English { get; set; }
        public string? Arabic { get; set; }
        public string? Turkish { get; set; }
        public int? CreatedBy { get; set; }
        public User User { get; set; }
        public Paint Paint { get; set; }
    }
}
