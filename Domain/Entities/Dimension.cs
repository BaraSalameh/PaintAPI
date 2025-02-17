namespace Domain.Entities
{
    public class Dimension
    {
        public int? ID { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? Depth { get; set; }
        public List<Paint_Detail> LstPaintDetails { get; set; }
    }
}
