using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace gs_csharp.src.Models
{
    public class User
    {
        // Oculta no POST (Id = 0), mostra no GET
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Totalmente oculto do Swagger + JSON
        [JsonIgnore]
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        // Oculta lista de Skills do JSON (POST/GET)
        [JsonIgnore]
        public ICollection<UserSkill> Skills { get; set; } = new List<UserSkill>();
        [JsonIgnore]
        public ICollection<CareerGapAnalysis> GapAnalyses { get; set; } = new List<CareerGapAnalysis>();
    }
}
