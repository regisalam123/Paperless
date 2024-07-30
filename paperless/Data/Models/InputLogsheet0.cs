namespace paperless.Data.Models
{
    public class InputLogsheet0
    {
        public string? Id { get; set; }
        public string? IdJam { get; set; }
        public string? LogId { get; set; }
        public string? LogIddescr { get; set; }
        public string? Maker { get; set; }
        public string? ItemUnitid { get; set; }
        public string? ItemUnitiddescr { get; set; }
        public string? Note { get; set; }
        public string? Kondisi { get; set; }

        public InputLogsheet1 [] Listlog1 { get; set; }
    }
}
