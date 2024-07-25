namespace paperless.Data.Models
{
    public class Pekerjaanck2
    {
        public string? Id { get; set; }
        public string? PekerjaanId { get; set; }
        public string? PekerjaanIdDescr { get; set; }
        public string? Maker { get; set; }
        public Pekerjaanck3[] ListCeklist { get; set; }
        public string? Foto { get; set; }
        public string? Foto2 { get; set; }
        public string? ItemUnitid { get; set; }
        public string? ItemUnitiddescr { get; set; }
    }
}
