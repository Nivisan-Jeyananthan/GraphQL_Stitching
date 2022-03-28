using System;
using System.Collections.Generic;

namespace LocalAuthority
{
    [GraphQLName("LocalAuthority")]
    public partial class TnPolitischeGemeinde
    {
        public int PgemId { get; set; }
        public int? PgemKanId { get; set; }
        public int? PgemPgem { get; set; }
        public int? PgemBfscode { get; set; }
        public string PgemBezeichnung { get; set; } = null!;
        public int? PgemGueltigAb { get; set; }
        public int? PgemGueltigBis { get; set; }
        public DateTime InsTime { get; set; }
        public string InsUser { get; set; } = null!;
        public DateTime? UpdTime { get; set; }
        public string? UpdUser { get; set; }
        public int? PgemBezId { get; set; }
        public int? PgemPregId { get; set; }
        public int? PgemRaglId { get; set; }
    }
}
