namespace Domain.Entities
{
    public class Paint_Detail
    {
        public int? ID { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? DimensionID { get; set; }
        public Dimension Dimension { get; set; }
        public int? CategoryLKPID { get; set; }
        public System_Lookup Category { get; set; }
        public int? StatusLKPID { get; set; }
        public System_Lookup Status { get; set; }
        public int? GlassLKPID { get; set; }
        public System_Lookup Glass { get; set; }
        public int? FrameLKPID { get; set; }
        public System_Lookup Frame { get; set; }
        public int? PaintID { get; set; }
        public Paint Paint { get; set; }
    }
}
