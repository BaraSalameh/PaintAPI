namespace Domain.Entities
{
    public class Lookup_Category
    {
        public int? ID { get; set; }
        public string? Name { get; set; }
        public List<System_Lookup> LstSystemLookups { get; set; }
    }
}
