namespace paperless.Data.Models
{
    public class FormPekerjaanck2
    {
        public string? Id { get; set; }
        public string? PekerjaanId { get; set; }
        public string? UraianId { get; set; }
        public string? UraianDescr { get; set; }
        public string? Status { get; set; }
        public string? foto3 { get; set; }
        public string? foto4 { get; set; }
        public string? foto5 { get; set; }
        public string? ItemUnit { get; set; }




        public FormPekerjaanck3[] Kondisi { get; set; }
    }
}
