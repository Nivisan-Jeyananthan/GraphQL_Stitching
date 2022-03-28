namespace Students.Infrastructure
{
    public partial class TLernender
    {
        public int LernId { get; set; }
        public int LernErduId { get; set; }
        public int? LernImpId { get; set; }
        public int? LernPublAbId { get; set; }
        public int? LernPublBisId { get; set; }
        public int LernPersId { get; set; }
        public int? LernStaaId { get; set; }
        public int? LernPgemId { get; set; }
        public int? LernSgemId { get; set; }
        public int? LernAnzahlRepetitionen { get; set; }
        public int? LernAnzahlSpruenge { get; set; }
        public int LernMatchingCode { get; set; }
        public int LernStatus { get; set; }
        public DateTime InsTime { get; set; }
        public string InsUser { get; set; } = null!;
        public DateTime? UpdTime { get; set; }
        public string? UpdUser { get; set; }
    }
}
