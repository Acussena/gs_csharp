using System.Text.Json.Serialization;

namespace gs_csharp.src.Models
{
    public class UserSkill
    {
        // Oculta no POST
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Id { get; set; }

        public string NomeSkill { get; set; } = string.Empty;
        public string Nivel { get; set; } = string.Empty;

        // UserId é obrigatório no POST
        public int UserId { get; set; }

        // Oculta relação do Swagger
        [JsonIgnore]
        public User? User { get; set; }
    }
}
