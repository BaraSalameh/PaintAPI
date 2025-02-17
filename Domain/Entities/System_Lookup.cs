namespace Domain.Entities
{
    public class System_Lookup
    {
        public int? ID { get; set; }
        public string? ValueSLID { get; set; }
        public int? LookupCategoryID { get; set; }
        public Lookup_Category LookupCategory { get; set; }
        public List<Paint_Detail> LstPaintDetailsOnCategory { get; set; }
        public List<Paint_Detail> LstPaintDetailsOnStatus { get; set; }
        public List<Paint_Detail> LstPaintDetailsOnGlass { get; set; }
        public List<Paint_Detail> LstPaintDetailsOnFrame { get; set; }
    }
}
