using System;
using System.Collections.Generic;

namespace gs_csharp.src.Models
{
    public class CareerGapAnalysis
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int FutureCareerId { get; set; }

        // Array de metaskills faltantes
        public string[] MetaskillsFaltantes { get; set; } = Array.Empty<string>();

        public int Score { get; set; }

        public DateTime DataAnalise { get; set; } = DateTime.UtcNow;

        public User User { get; set; } = null!;
        public FutureCareer FutureCareer { get; set; } = null!;
    }
}
