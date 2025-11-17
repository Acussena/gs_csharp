using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace gs_csharp.src.Models
{
    public class FutureCareer
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;

        public int UserId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }

        [JsonIgnore]
        public ICollection<CareerGapAnalysis> GapAnalyses { get; set; } = new List<CareerGapAnalysis>();
    }
}
