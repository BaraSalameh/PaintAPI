namespace Domain.Entities
{
    public class Paint
    {
        public int? ID { get; set; }
        public int? NameSLID { get; set; }
        public System_Language Name { get; set; }
        public string? ImagePath { get; set; }
        public int? UserID { get; set; }
        public User User { get; set; }
        public Paint_Detail PaintDetail { get; set; }
    }
}
